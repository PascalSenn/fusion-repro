﻿using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Conversations;

public class Query
{
    public IEnumerable<ConversationModel> GetConversations() => new[]
    {
        new ConversationModel()
        {
            Conversation = "Hello, how are you?",
        },
        new ConversationModel()
        {
            Conversation = "I'm fine, thank you.",
        }
    };
}

public class ConversationModel
{
    public Guid LeadId { get; set; }

    public string? Conversation { get; set; }
}

[ExtendObjectType<ConversationModel>()]
public class ConversationModelExtensions
{
    [BindMember(nameof(ConversationModel.LeadId))]
    public LeadModel GetLead([Parent] ConversationModel parent) => new(parent.LeadId);
}

public record LeadModel([property: ID] Guid Id);
