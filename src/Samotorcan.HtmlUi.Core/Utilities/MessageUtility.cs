﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace Samotorcan.HtmlUi.Core.Utilities
{
    /// <summary>
    /// Message utility.
    /// </summary>
    internal class MessageUtility
    {
        #region Properties
        #region Public

        #region SendMessage
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <param name="cefBrowser">The cef browser.</param>
        /// <param name="name">The name.</param>
        /// <param name="callbackId">The callback identifier.</param>
        /// <param name="data">The data.</param>
        /// <exception cref="System.ArgumentNullException">
        /// cefBrowser
        /// or
        /// name
        /// </exception>
        public static void SendMessage<TData>(CefBrowser cefBrowser, string name, Guid? callbackId, TData data)
        {
            if (cefBrowser == null)
                throw new ArgumentNullException("cefBrowser");

            if (string.IsNullOrWhiteSpace("name"))
                throw new ArgumentNullException("name");

            var message = JsonUtility.SerializeToBson(new Message<TData>(callbackId, data));

            SendBinaryMessage(cefBrowser, name, message);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="cefBrowser">The cef browser.</param>
        /// <param name="name">The name.</param>
        /// <param name="callbackId">The callback identifier.</param>
        /// <exception cref="System.ArgumentNullException">
        /// cefBrowser
        /// or
        /// name
        /// </exception>
        public static void SendMessage(CefBrowser cefBrowser, string name, Guid? callbackId)
        {
            if (cefBrowser == null)
                throw new ArgumentNullException("cefBrowser");

            if (string.IsNullOrWhiteSpace("name"))
                throw new ArgumentNullException("name");

            var message = JsonUtility.SerializeToBson(new Message(callbackId));

            SendBinaryMessage(cefBrowser, name, message);
        }
        #endregion
        #region DeserializeMessage
        /// <summary>
        /// Deserializes the message.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        public static Message<TType> DeserializeMessage<TType>(CefProcessMessage processMessage)
        {
            return JsonUtility.DeserializeFromBson<Message<TType>>(processMessage.Arguments.GetBinary(0).ToArray());
        }

        /// <summary>
        /// Deserializes the message.
        /// </summary>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        public static Message DeserializeMessage(CefProcessMessage processMessage)
        {
            return JsonUtility.DeserializeFromBson<Message>(processMessage.Arguments.GetBinary(0).ToArray());
        }
        #endregion
        #region DeserializeAnonymousMessage
        /// <summary>
        /// Deserializes the anonymous message.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="processMessage">The process message.</param>
        /// <param name="anonymousObject">The anonymous object.</param>
        /// <returns></returns>
        public static Message<TType> DeserializeAnonymousMessage<TType>(CefProcessMessage processMessage, TType anonymousObject)
        {
            return JsonUtility.DeserializeFromBson<Message<TType>>(processMessage.Arguments.GetBinary(0).ToArray());
        }
        #endregion

        #endregion
        #region Private

        #region SendBinaryMessage
        /// <summary>
        /// Sends the binary message.
        /// </summary>
        /// <param name="cefBrowser">The cef browser.</param>
        /// <param name="name">The name.</param>
        /// <param name="message">The message.</param>
        private static void SendBinaryMessage(CefBrowser cefBrowser, string name, byte[] message)
        {
            using (var processMessage = CefProcessMessage.Create(name))
            {
                try
                {
                    using (var binaryValue = CefBinaryValue.Create(message))
                    {
                        processMessage.Arguments.SetBinary(0, binaryValue);

                        cefBrowser.SendProcessMessage(CefProcessId.Browser, processMessage);
                    }
                }
                finally
                {
                    processMessage.Arguments.Dispose();
                }
            }
        }
        #endregion

        #endregion
        #endregion
    }
}
