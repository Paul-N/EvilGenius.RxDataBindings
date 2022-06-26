// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.


//Stolen from MvvmCross/MvvmCross/Base/MvxValueEventArgs.cs
namespace System
{
#nullable enable
    public class ValueEventArgs<T> : EventArgs
    {
        public ValueEventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
#nullable restore
}