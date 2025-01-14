﻿using AnZwDev.ALTools.ALSymbols;
using AnZwDev.ALTools.CodeTransformations;
using AnZwDev.ALTools.Extensions;
using Microsoft.Dynamics.Nav.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnZwDev.ALTools.WorkspaceCommands
{
    public class AddFieldCaptionsWorkspaceCommand : SyntaxRewriterWorkspaceCommand<FieldCaptionSyntaxRewriter>
    {

        public static string LockRemovedFieldsParameterName = "lockRemovedFields";
        public static string SortPropertiesParameterName = "sortProperties";

        public AddFieldCaptionsWorkspaceCommand(ALDevToolsServer alDevToolsServer) : base(alDevToolsServer, "addFieldCaptions")
        {
        }

        protected override void SetParameters(string sourceCode, string projectPath, string filePath, TextSpan span, Dictionary<string, string> parameters)
        {
            base.SetParameters(sourceCode, projectPath, filePath, span, parameters);
            this.SyntaxRewriter.SortProperties = parameters.GetBoolValue(SortPropertiesParameterName);
            this.SyntaxRewriter.LockRemovedFields = parameters.GetBoolValue(LockRemovedFieldsParameterName);
        }


    }
}
