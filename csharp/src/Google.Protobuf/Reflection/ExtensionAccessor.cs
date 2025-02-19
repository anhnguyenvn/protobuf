﻿#region Copyright notice and license
// Protocol Buffers - Google's data interchange format
// Copyright 2008 Google Inc.  All rights reserved.
// https://developers.google.com/protocol-buffers/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Reflection;

namespace Google.Protobuf.Reflection
{
    internal sealed class ExtensionAccessor : IFieldAccessor
    {
        private readonly Extension extension;
        private readonly ReflectionUtil.IExtensionReflectionHelper helper;

        internal ExtensionAccessor(FieldDescriptor descriptor)
        {
            Descriptor = descriptor;
            extension = descriptor.Extension;
            helper = ReflectionUtil.CreateExtensionHelper(extension);
        }

        public FieldDescriptor Descriptor { get; }

        public void Clear(IMessage message)
        {
            //helper.ClearExtension(message);
            var T1 = extension.TargetType;
            var T3 = extension.GetType().GenericTypeArguments[1];
            MethodInfo method = helper.GetType().GetTypeInfo().GetDeclaredMethod(nameof(ReflectionUtil.ExtensionReflectionHelper.ClearExtension));
            MethodInfo generic = method.MakeGenericMethod(T1, T3);
            generic.Invoke(helper, new object[] { message });
        }

        public bool HasValue(IMessage message)
        {
            //return helper.HasExtension(message);

            var T1 = extension.TargetType;
            var T3 = extension.GetType().GenericTypeArguments[1];
            MethodInfo method = helper.GetType().GetTypeInfo().GetDeclaredMethod(nameof(ReflectionUtil.ExtensionReflectionHelper.HasExtension));
            MethodInfo generic = method.MakeGenericMethod(T1, T3);
            return (bool) generic.Invoke(helper, new object[] { message });
        }

        public object GetValue(IMessage message)
        {
            //return helper.GetExtension(message
            var T1 = extension.TargetType;
            var T3 = extension.GetType().GenericTypeArguments[1];
            MethodInfo method = helper.GetType().GetTypeInfo().GetDeclaredMethod(nameof(ReflectionUtil.ExtensionReflectionHelper.GetExtension));
            MethodInfo generic = method.MakeGenericMethod(T1, T3);
            return generic.Invoke(helper, new object[] { message });
        }

        public void SetValue(IMessage message, object value)
        {
            //helper.SetExtension(message, value);

            var T1 = extension.TargetType;
            var T3 = extension.GetType().GenericTypeArguments[1];
            MethodInfo method = helper.GetType().GetTypeInfo().GetDeclaredMethod(nameof(ReflectionUtil.ExtensionReflectionHelper.SetExtension));
            MethodInfo generic = method.MakeGenericMethod(T1, T3);
            generic.Invoke(helper, new object[] { message });
        }
    }
}
