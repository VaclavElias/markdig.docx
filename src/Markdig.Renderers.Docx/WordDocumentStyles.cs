﻿namespace Markdig.Renderers.Docx;

public class WordDocumentStyles
{
    public Dictionary<int, string?> Headings { get; } = new()
    {
        [0] = "Title",
        [1] = "MDHeading1",
        [2] = "MDHeading2",
        [3] = "MDHeading3",
        [4] = "MDHeading4",
        [5] = "MDHeading5",
    };

    public string UndefinedHeading { get; set; } = "MDHeading5";

    public string Paragraph { get; set; } = "MDParagraphTextBody";

    public string CodeBlock { get; set; } = "MDPreformattedText";

    public string UnknownFormatting { get; set; } = "MDNormal";
    public string Hyperlink { get; set; } = "MDHyperlink";

    public string List { get; set; } = "MDList";
    public string? ListOrdered { get; set; } = "MDListNumber";
    public string? ListBullet { get; set; } = "MDListBullet";
    
    public string? Quote { get; set; } = "MDQuotations";

    public int CodeTabSpaces { get; set; } = 3;

    public string CodeTab => new string(' ', CodeTabSpaces);
    public string? HorizontalLine { get; set; } = "MDHorizontalLine";
}