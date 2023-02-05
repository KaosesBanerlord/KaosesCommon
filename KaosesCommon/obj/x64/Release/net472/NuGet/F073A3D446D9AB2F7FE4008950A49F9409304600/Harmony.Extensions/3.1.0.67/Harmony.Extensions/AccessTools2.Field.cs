// <auto-generated>
//   This code file has automatically been added by the "Harmony.Extensions" NuGet package (https://www.nuget.org/packages/Harmony.Extensions).
//   Please see https://github.com/BUTR/Harmony.Extensions for more information.
//
//   IMPORTANT:
//   DO NOT DELETE THIS FILE if you are using a "packages.config" file to manage your NuGet references.
//   Consider migrating to PackageReferences instead:
//   https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference
//   Migrating brings the following benefits:
//   * The "Harmony.Extensions" folder and the "AccessTools2.Field.cs" file don't appear in your project.
//   * The added file is immutable and can therefore not be modified by coincidence.
//   * Updating/Uninstalling the package will work flawlessly.
// </auto-generated>

#region License
// MIT License
//
// Copyright (c) Bannerlord's Unofficial Tools & Resources, Andreas Pardeike
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

#if !HARMONYEXTENSIONS_DISABLE
#nullable enable
#if !HARMONYEXTENSIONS_ENABLEWARNINGS
#pragma warning disable
#endif

namespace HarmonyLib.BUTR.Extensions
{
    using global::System;
    using global::System.Diagnostics;
    using global::System.Reflection;

    /// <summary>An extension of Harmony's helper class for reflection related functions</summary>
#if !HARMONYEXTENSIONS_PUBLIC
    internal
#else
    public
#endif
        static partial class AccessTools2
    {
        /// <summary>Gets the reflection information for a directly declared field</summary>
        /// <param name="type">The class/type where the field is defined</param>
        /// <param name="name">The name of the field</param>
        /// <returns>A field or null when type/name is null or when the field cannot be found</returns>
        ///
        public static FieldInfo? DeclaredField(Type type, string name)
        {
            if (type is null)
            {
                Trace.TraceError("AccessTools2.DeclaredField: 'type' is null");
                return null;
            }
            if (name is null)
            {
                Trace.TraceError($"AccessTools2.DeclaredField: type '{type}', 'name' is null");
                return null;
            }
            var fieldInfo = type.GetField(name, AccessTools.allDeclared);
            if (fieldInfo is null)
            {
                Trace.TraceError($"AccessTools2.DeclaredField: Could not find field for type '{type}' and name '{name}'");
                return null;
            }
            return fieldInfo;
        }

        /// <summary>Gets the reflection information for a field by searching the type and all its super types</summary>
        /// <param name="type">The class/type where the field is defined</param>
        /// <param name="name">The name of the field (case sensitive)</param>
        /// <returns>A field or null when type/name is null or when the field cannot be found</returns>
        ///
        public static FieldInfo? Field(Type type, string name)
        {
            if (type is null)
            {
                Trace.TraceError("AccessTools2.Field: 'type' is null");
                return null;
            }
            if (name is null)
            {
                Trace.TraceError($"AccessTools2.Field: type '{type}', 'name' is null");
                return null;
            }
            var fieldInfo = FindIncludingBaseTypes(type, t => t.GetField(name, AccessTools.all));
            if (fieldInfo is null)
                Trace.TraceError($"AccessTools2.Field: Could not find field for type '{type}' and name '{name}'");
            return fieldInfo;
        }

        //

        public static FieldInfo? DeclaredField(string typeColonFieldname)
        {
            if (!TryGetComponents(typeColonFieldname, out var type, out var name))
            {
                Trace.TraceError($"AccessTools2.Field: Could not find type or field for '{typeColonFieldname}'");
                return null;
            }

            return DeclaredField(type, name);
        }
        
        public static FieldInfo? Field(string typeColonFieldname)
        {
            if (!TryGetComponents(typeColonFieldname, out var type, out var name))
            {
                Trace.TraceError($"AccessTools2.Field: Could not find type or field for '{typeColonFieldname}'");
                return null;
            }

            return Field(type, name);
        }
    }
}

#pragma warning restore
#nullable restore
#endif // HARMONYEXTENSIONS_DISABLE