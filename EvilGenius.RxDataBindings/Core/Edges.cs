using System;

namespace EvilGenius.RxDataBindings.Core;

[Flags]
public enum Edges : byte
{
    All = 0,
    Left = 1,
    Top = 2,
    Right = 4,
    Bottom = 8,
    Start = 16,
    End = 32
}
