// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.RecommendedAction.Model;
using Microsoft.Azure.Commands.Sql.RecommendedAction.Service;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.RecommendedAction.Cmdlet
{
    /// <summary>
    /// The base class of cmdlets for Azure SQL Server Recommended Action
    /// </summary>
    public abstract class AzureSqlServerRecommendedActionCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlServerRecommendedActionModel>, AzureSqlServerRecommendedActionAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Server name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the advisor.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Server Advisor name.")]
        [ValidateNotNullOrEmpty]
        public string AdvisorName { get; set; }

        /// <summary>
        /// Initializes the model adapter
        /// </summary>
        /// <returns>The advisor adapter</returns>
        protected override AzureSqlServerRecommendedActionAdapter InitModelAdapter()
        {
            return new AzureSqlServerRecommendedActionAdapter(DefaultProfile.DefaultContext);
        }
    }
}
