﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samotorcan.HtmlUi.Core
{
    /// <summary>
    /// ObservableCollectionChange
    /// </summary>
    internal class ObservableCollectionChange
    {
        #region Properties
        #region Public

        #region Action
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollectionChangeAction Action { get; set; }
        #endregion
        #region NewItems
        /// <summary>
        /// Gets or sets the new items.
        /// </summary>
        /// <value>
        /// The new items.
        /// </value>
        public IList NewItems { get; set; }
        #endregion
        #region NewStartingIndex
        /// <summary>
        /// Gets or sets the new index of the starting.
        /// </summary>
        /// <value>
        /// The new index of the starting.
        /// </value>
        public int NewStartingIndex { get; set; }
        #endregion
        #region OldItems
        /// <summary>
        /// Gets or sets the old items.
        /// </summary>
        /// <value>
        /// The old items.
        /// </value>
        public IList OldItems { get; set; }
        #endregion
        #region OldStartingIndex
        /// <summary>
        /// Gets or sets the old index of the starting.
        /// </summary>
        /// <value>
        /// The old index of the starting.
        /// </value>
        public int OldStartingIndex { get; set; }
        #endregion

        #endregion
        #endregion
    }
}