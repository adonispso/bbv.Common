//-------------------------------------------------------------------------------
// <copyright file="IEventTopicInfo.cs" company="bbv Software Services AG">
//   Copyright (c) 2008-2011 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace bbv.Common.EventBroker.Internals
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Represents a point of information on a certain topic between the topic publishers and the topic subscribers.
    /// </summary>
    public interface IEventTopicInfo
    {
        /// <summary>
        /// Gets the URI for the event topic. This URI is the unique identifier for this event topic.
        /// </summary>
        /// <value>The URI of this event topic.</value>
        string Uri { get; }

        /// <summary>
        /// Gets the publications for the event topic.
        /// </summary>
        /// <remarks>The publications are frequently cleaned internally when
        /// necessary. Therefore the publications are only valid at the time
        /// when they are requested and should not be cached or referenced longer
        /// then necessary.</remarks>
        IEnumerable<IPublication> Publications { get; }

        /// <summary>
        /// Gets the subscriptions for the event topic.
        /// </summary>
        /// <remarks>The subscriptions are frequently cleaned internally when
        /// necessary. Therefore the subscriptions are only valid at the time
        /// when they are requested and should not be cached or referenced longer
        /// then necessary.</remarks>
        IEnumerable<ISubscription> Subscriptions { get; }

        /// <summary>
        /// Describes this event topic:
        /// publications, subscriptions, names, thread options, scopes, event args.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void DescribeTo(TextWriter writer);

        /// <summary>
        /// Fires the <see cref="IEventTopic"/>.
        /// </summary>
        /// <param name="sender">The object that acts as the sender of the event to the subscribers. 
        /// Not always the publisher (it's the sender provided in the event call).</param>
        /// <param name="e">An <see cref="EventArgs"/> instance to be passed to the subscribers.</param>
        /// <param name="publication">The publication firing the event topic.</param>
        void Fire(object sender, EventArgs e, IPublication publication);
    }
}