# Skybrud.SyntaxHighlighter

This package lets you show code examples with syntax highlighting for a few for languages. The syntax highlighting will generate HTML for you yo style using CSS.

### Installation

1. [**NuGet Package**][NuGetPackage]  
Install this NuGet package in your Visual Studio project. Makes updating easy.

2. [**ZIP file**][GitHubRelease]  
Grab a ZIP file of the latest release; unzip and move `Skybrud.SyntaxHighlighter.dll` to the bin directory of your project.

[NuGetPackage]: https://www.nuget.org/packages/Skybrud.SyntaxHighlighter
[GitHubRelease]: https://github.com/abjerner/Skybrud.SyntaxHighlighter/releases/latest
[Changelog]: https://github.com/abjerner/Skybrud.SyntaxHighlighter/blob/master/CHANGELOG.md
[Issues]: https://github.com/abjerner/Skybrud.SyntaxHighlighter/issues


### How to use?

```C#
string html = Highlighter.HighlightXml(xml);
```

```C#
string html = Highlighter.HighlightJson(json);
```

```C#
string html = Highlighter.HighlightJavaScript(javascript);
```

```C#
string html = Highlighter.HighlightCSharp(csharp);
```

### Styling

Since this package is inspired by the syntax highlighting here on GitHub, the CSS below will match the colors of GitHub.

```CSS
.highlight.csharp { color: #333; font-size: 12px; line-height: 16px; }
.highlight.csharp .identifier { color: #795da3; }
.highlight.csharp .keyword { color: #a71d5d; }
.highlight.csharp .comment { color: #969896; }
.highlight.csharp .string { color: #df5000; }
.highlight.csharp .constant { color: #0086b3; }
    
.highlight.xml { color: #333; font-size: 12px; line-height: 16px; }
.highlight.xml .cdata { color: #df5000; }
.highlight.xml .cdatavalue { color: #df5000; }
.highlight.xml .element { color: #63a35c; }
.highlight.xml .attribute { color: #795da3; }
.highlight.xml .string { color: #df5000; }
.highlight.xml .quot { color: #df5000; }
.highlight.xml .comment { color: #969896; }
    
.highlight.javascript { color: #333; font-size: 12px; line-height: 16px; }
.highlight.javascript .keyword { color: #a71d5d; }
.highlight.javascript .constant { color: #0086b3; }
.highlight.javascript .string { color: #df5000; }
    
.highlight.json { color: #333; font-size: 12px; line-height: 16px; }
.highlight.json .keyword { color: #a71d5d; }
.highlight.json .constant { color: #0086b3; }
.highlight.json .string { color: #df5000; }
```
