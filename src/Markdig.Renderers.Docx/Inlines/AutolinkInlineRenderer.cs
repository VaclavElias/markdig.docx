﻿using System.Diagnostics;
using DocumentFormat.OpenXml.Wordprocessing;
using Markdig.Syntax.Inlines;
using Microsoft.Extensions.Logging;

namespace Markdig.Renderers.Docx.Inlines;

public class AutolinkInlineRenderer : DocxObjectRenderer<AutolinkInline>
{
    private int _hyperlinkIdCounter;

    protected override void Write(DocxDocumentRenderer renderer, AutolinkInline obj)
    {
        base.Write(renderer, obj);
        base.Write(renderer, obj);
        
        var uriString = obj.Url;
        var title = uriString;
        
        renderer.Log.LogDebug($"Rendering link to {uriString}");

        if (obj.IsEmail && !uriString.ToLower().StartsWith("mailto:"))
        {
            uriString = "mailto:" + uriString;
        }
        
        Uri? uri = null;

        var isAbsoluteUri = Uri.TryCreate(uriString, UriKind.Absolute, out uri);

        if (!isAbsoluteUri)
        {
            Uri.TryCreate(uriString, UriKind.Relative, out uri);
        }


        if (uri == null) return;
        
        var linkId = $"AL{_hyperlinkIdCounter++}";
        Debug.Assert(renderer.Document.MainDocumentPart != null, "Document.MainDocumentPart != null");

        renderer.Document.MainDocumentPart.AddHyperlinkRelationship(uri, isAbsoluteUri, linkId);
        var hl = new Hyperlink
        {
            Id = linkId,
        };
        
        renderer.Cursor.Write(hl);
        renderer.Cursor.GoInto(hl);

        var run = new Run(new Text(title));
        run.SetStyle(renderer.Styles.Hyperlink);
        renderer.Cursor.Write(run);
        
        renderer.Cursor.GoOut();
    }
}