﻿using System;
using System.Collections.Generic;
using LLVMSharp;
using Mono.Cecil;
using Santol.Generator;
using Santol.Loader;

namespace Santol.IR
{
    public class SequentialStructType : IType
    {
        public string Name { get; }
        public string MangledName { get; }
        public bool Packed { get; }
        private IList<IField> _fields;

        public SequentialStructType(string name, bool packed)
        {
            Name = name;
            MangledName = $"SS_{name.Replace('.', '_').Replace("*", "PTR")}";
            Packed = packed;
            _fields = new List<IField>();
        }

        public void AddField(IField field)
        {
            _fields.Add(field);
        }

        public LLVMTypeRef GetType(CodeGenerator codeGenerator)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef GenerateConstantValue(CodeGenerator codeGenerator, object value)
        {
            throw new NotSupportedException("Constant sequential structs not supported");
        }

        public LLVMValueRef? ConvertTo(CodeGenerator codeGenerator, IType type, LLVMValueRef value)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef? ConvertFrom(CodeGenerator codeGenerator, IType type, LLVMValueRef value)
        {
            throw new NotImplementedException();
        }

        public IType GetMostComplexType(IType other)
        {
            throw new NotImplementedException();
        }

        public IField ResolveField(FieldReference field)
        {
            throw new NotImplementedException();
        }

        public LLVMValueRef GetFieldAddress(CodeGenerator codeGenerator, LLVMValueRef objectPtr, IField field)
        {
            throw new NotImplementedException();
        }

        public IMethod ResolveMethod(MethodReference method)
        {
            throw new NotImplementedException();
        }

        public void Generate(AssemblyLoader assemblyLoader, CodeGenerator codeGenerator)
        {
            foreach (IField field in _fields)
                field.Generate(assemblyLoader, codeGenerator);
            //            throw new NotImplementedException();
        }
    }
}