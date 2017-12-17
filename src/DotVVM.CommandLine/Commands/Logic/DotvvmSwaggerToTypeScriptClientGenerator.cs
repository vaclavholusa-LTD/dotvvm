﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJsonSchema;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag;
using NSwag.CodeGeneration;
using NSwag.CodeGeneration.TypeScript;
using NSwag.CodeGeneration.TypeScript.Models;

namespace DotVVM.CommandLine.Commands.Logic
{
    public class DotvvmSwaggerToTypeScriptClientGenerator : SwaggerToTypeScriptClientGenerator
    {
        private readonly TypeScriptTypeResolver resolver;

        public DotvvmSwaggerToTypeScriptClientGenerator(SwaggerDocument document, SwaggerToTypeScriptClientGeneratorSettings settings, TypeScriptTypeResolver resolver) : base(document, settings, resolver)
        {
            this.resolver = resolver;
        }

        protected override TypeScriptOperationModel CreateOperationModel(SwaggerOperation operation, ClientGeneratorBaseSettings settings)
        {
            var model = new DotvvmTypeScriptOperationModel(operation, Settings, this, resolver);
            HandleAsObjectParameters(operation, model, (SwaggerToTypeScriptClientGeneratorSettings)settings);
            return model;
        }

        private void HandleAsObjectParameters(SwaggerOperation operation, DotvvmTypeScriptOperationModel model, SwaggerToTypeScriptClientGeneratorSettings settings)
        {
            // find groups of parameters that should be treated as one
            var parameters = model.QueryParameters.Where(p => p.Name.Contains(".") && p.Schema.ExtensionData.ContainsKey("x-dotvvm-wrapperType"));
            var groups = parameters.GroupBy(p => p.Name.Substring(0, p.Name.IndexOf("."))).ToList();
            foreach (var g in groups)
            {
                var swaggerParameter = new SwaggerParameter() {
                    Name = g.Key,
                    Schema = new JsonSchema4(),
                    Kind = SwaggerParameterKind.Query
                };
                var newParameter = new DotvvmTypeScriptParameterModel(g.Key, g.Key, "any", swaggerParameter, operation.Parameters, settings, this, model);
                var targetIndex = g.Min(p => model.Parameters.IndexOf(p));
                foreach (var p in g)
                {
                    ((DotvvmTypeScriptParameterModel)p).CustomInitializer = $"let {p.VariableName} = {g.Key} !== undefined ? {p.Name} : {g.Key};";
                }
                model.Parameters.Insert(targetIndex, newParameter);
            }
        }
    }
}
