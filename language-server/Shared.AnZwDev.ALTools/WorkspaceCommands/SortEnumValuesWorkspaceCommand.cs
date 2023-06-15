#if !NAV2018
using AnZwDev.ALTools.CodeTransformations;

namespace AnZwDev.ALTools.WorkspaceCommands
{
    public class SortEnumValuesWorkspaceCommand : SyntaxRewriterWorkspaceCommand<SortEnumValuesSyntaxRewriter>
    {
        public SortEnumValuesWorkspaceCommand(ALDevToolsServer alDevToolsServer) : base(alDevToolsServer, "sortEnumValues")
        {
        }
    }
}
#endif