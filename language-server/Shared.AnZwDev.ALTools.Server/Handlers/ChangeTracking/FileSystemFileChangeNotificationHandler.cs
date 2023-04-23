﻿using AnZwDev.ALTools.Server.Contracts.ChangeTracking;
using AnZwDev.VSCodeLangServer.Protocol.Server;
using AnZwDev.VSCodeLangServer.Protocol.MessageProtocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnZwDev.ALTools.Server.Handlers.ChangeTracking
{
    public class FileSystemFileChangeNotificationHandler : BaseALNotificationHandler<FileSystemChangeNotificationRequest>
    {

        public FileSystemFileChangeNotificationHandler(ALDevToolsServer alDevToolsServer, LanguageServerHost languageServerHost) : base(alDevToolsServer, languageServerHost, "ws/fsFileChange")
        {
        }

#pragma warning disable 1998
        public override async Task HandleNotification(FileSystemChangeNotificationRequest parameters, NotificationContext context)
        {
            this.Server.Workspace.OnFileSystemFileChange(parameters.path);

        }
#pragma warning restore 1998

    }
}