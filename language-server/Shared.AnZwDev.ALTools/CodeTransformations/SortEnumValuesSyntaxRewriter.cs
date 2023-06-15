#if !NAV2018
using AnZwDev.ALTools.Core;
using Microsoft.Dynamics.Nav.CodeAnalysis;
using Microsoft.Dynamics.Nav.CodeAnalysis.Syntax;
using System.Collections.Generic;

namespace AnZwDev.ALTools.CodeTransformations
{
    public class SortEnumValuesSyntaxRewriter : ALSyntaxRewriter
    {
        #region Enum values comparer

        protected class EnumValueComparer<T> : IComparer<T>
        {
            protected static IComparer<string> _stringComparer = new SyntaxNodeNameComparer();

            public EnumValueComparer()
            {
            }

            protected long GetEnumId(EnumValueSyntax node)
            {
                if ((node != null) && (node.Id != null) && (!string.IsNullOrWhiteSpace(node.Id.ValueText)))
                {
                    if (long.TryParse(node.Id.ValueText, out long value))
                        return value;
                }

                return 0;
            }

            public int Compare(T x, T y)
            {
                EnumValueSyntax enumX = x as EnumValueSyntax;
                EnumValueSyntax enumY = y as EnumValueSyntax;

                long xId = this.GetEnumId(enumX);
                long yId = this.GetEnumId(enumY);

                int value = xId.CompareTo(yId);
                if (value != 0)
                    return value;

                return _stringComparer.Compare(enumX.GetNameStringValue(), enumY.GetNameStringValue());
            }
        }

        #endregion

        public SortEnumValuesSyntaxRewriter()
        {
        }

        public override SyntaxNode VisitEnumType(EnumTypeSyntax node)
        {
            if ((node.Values != null) && (node.Values.Count > 0))
            {
                EnumValueComparer<EnumValueSyntax> comparer = new EnumValueComparer<EnumValueSyntax>();
                SyntaxList<EnumValueSyntax> fields = SyntaxNodesGroupsTree<EnumValueSyntax>.SortSyntaxList(
                    node.Values, comparer, out bool sorted);

                if (sorted)
                    this.NoOfChanges++;

                return node.WithValues(fields);
            }

            return base.VisitEnumType(node);
        }

        public override SyntaxNode VisitEnumExtensionType(EnumExtensionTypeSyntax node)
        {
            if ((node.Values != null) && (node.Values.Count > 0))
            {
                EnumValueComparer<EnumValueSyntax> comparer = new EnumValueComparer<EnumValueSyntax>();
                SyntaxList<EnumValueSyntax> values = SyntaxNodesGroupsTree<EnumValueSyntax>.SortSyntaxList(
                    node.Values, comparer, out bool sorted);

                if (sorted)
                    this.NoOfChanges++;

                return node.WithValues(values);
            }

            return base.VisitEnumExtensionType(node);
        }
    }
}
#endif
