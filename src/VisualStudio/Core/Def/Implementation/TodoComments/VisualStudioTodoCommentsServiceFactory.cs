﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable enable

using System;
using System.Composition;
using Microsoft.CodeAnalysis.Editor.Shared.Utilities;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.VisualStudio.LanguageServices.Implementation.ProjectSystem;

namespace Microsoft.VisualStudio.LanguageServices.Implementation.TodoComments
{
    [ExportWorkspaceServiceFactory(typeof(ITodoCommentsService), ServiceLayer.Host), Shared]
    internal class VisualStudioTodoCommentsServiceFactory : IWorkspaceServiceFactory
    {
        private readonly IThreadingContext _threadingContext;

        [ImportingConstructor]
        [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
        public VisualStudioTodoCommentsServiceFactory(IThreadingContext threadingContext)
            => _threadingContext = threadingContext;

        public IWorkspaceService? CreateService(HostWorkspaceServices workspaceServices)
        {
            if (!(workspaceServices.Workspace is VisualStudioWorkspaceImpl workspace))
                return null;

            return new VisualStudioTodoCommentsService(workspace, _threadingContext);
        }
    }
}
