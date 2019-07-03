﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Templates.Cli.Commands.Contracts;
using Microsoft.Templates.Cli.Models;
using Microsoft.Templates.Cli.Services.Contracts;
using Newtonsoft.Json;

namespace Microsoft.Templates.Cli.Commands.Handlers
{
    public class GenerateHandler : ICommandHandler<GenerateCommand>
    {
        private readonly IGenerateService _generateService;

        public GenerateHandler(IGenerateService generateService)
        {
            _generateService = generateService;
        }

        public async Task<int> ExecuteAsync(GenerateCommand command)
        {
            var data = string.Join(' ', command.GenerationDataJson);
            var generationData = JsonConvert.DeserializeObject<GenerationData>(data);
            await _generateService.GenerateAsync(generationData);

            return 0;
        }
    }
}