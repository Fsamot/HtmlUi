﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace Samotorcan.HtmlUi.Core.Handlers.Browser
{
    /// <summary>
    /// Default CEF keyboard handler.
    /// </summary>
    internal class DefaultCefKeyboardHandler : CefKeyboardHandler
    {
        #region Methods
        #region Protected

        #region OnPreKeyEvent
        /// <summary>
        /// Called before a keyboard event is sent to the renderer. |event| contains
        /// information about the keyboard event. |os_event| is the operating system
        /// event message, if any. Return true if the event was handled or false
        /// otherwise. If the event will be handled in OnKeyEvent() as a keyboard
        /// shortcut set |is_keyboard_shortcut| to true and return false.
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="keyEvent"></param>
        /// <param name="os_event"></param>
        /// <param name="isKeyboardShortcut"></param>
        /// <returns></returns>
        protected override bool OnPreKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, IntPtr os_event, out bool isKeyboardShortcut)
        {
            if (keyEvent == null)
                throw new ArgumentNullException("keyEvent");

            isKeyboardShortcut = false;

            BaseApplication.Current.Window.TriggerKeyPress(keyEvent.WindowsKeyCode);

            return false;
        }
        #endregion

        #endregion
        #endregion
    }
}
