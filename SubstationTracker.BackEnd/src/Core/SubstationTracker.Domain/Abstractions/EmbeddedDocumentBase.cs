﻿namespace SubstationTracker.Domain.Abstractions;

public class EmbeddedDocumentBase : IEmbeddedDocument
{
    public DateTime CreatedDate { get; set; }
}