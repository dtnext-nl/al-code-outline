﻿using AnZwDev.ALTools.Extensions;
using Microsoft.Dynamics.Nav.CodeAnalysis;
using Microsoft.Dynamics.Nav.CodeAnalysis.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnZwDev.ALTools.CodeTransformations
{
    public class DataClassificationSyntaxRewriter : ALSyntaxRewriter
    {

        private string _tableDataClassification = null;
        public bool SortProperties { get; set; }

        private SortPropertiesSyntaxRewriter _sortPropertiesSyntaxRewriter;

        public string DataClassification { get; set; }

        public DataClassificationSyntaxRewriter()
        {
            this.DataClassification = null;
            _sortPropertiesSyntaxRewriter = new SortPropertiesSyntaxRewriter();
        }

        public override SyntaxNode VisitTable(TableSyntax node)
        {            
            PropertySyntax propertySyntax = node.GetProperty("DataClassification");
            if (propertySyntax == null)
            {
                NoOfChanges++;
                node = node.AddPropertyListProperties(
                    this.CreateDataClassificationProperty(node));
                if (SortProperties)
                    node = node.WithPropertyList(_sortPropertiesSyntaxRewriter.SortPropertyList(node.PropertyList, out _));
                _tableDataClassification = DataClassification;
            }
            else
            {
                _tableDataClassification = propertySyntax.Value.ToString();
                if ((String.IsNullOrWhiteSpace(_tableDataClassification)) ||
                    (_tableDataClassification.Equals("ToBeClassified", StringComparison.CurrentCultureIgnoreCase)))
                {
                    NoOfChanges++;
                    node = node.ReplaceNode(propertySyntax, this.CreateDataClassificationProperty(node));
                    _tableDataClassification = DataClassification;
                }
            }
            var tableNode = base.VisitTable(node);
            _tableDataClassification = null;
            return tableNode;
        }

        public override SyntaxNode VisitTableExtension(TableExtensionSyntax node)
        {
            _tableDataClassification = null;
            return base.VisitTableExtension(node);
        }

        public override SyntaxNode VisitField(FieldSyntax node)
        {
            PropertyValueSyntax fieldClass = node.GetPropertyValue("FieldClass");
            if ((fieldClass == null) || (fieldClass.ToString().Equals("Normal", StringComparison.CurrentCultureIgnoreCase)))
            {
                PropertySyntax propertySyntax = node.GetProperty("DataClassification");
                if (propertySyntax == null)
                {
                    if (String.IsNullOrWhiteSpace(_tableDataClassification))
                    {
                        NoOfChanges++;
                        node = node.AddPropertyListProperties(
                            this.CreateDataClassificationProperty(node));
                        if (SortProperties)
                            node = node.WithPropertyList(_sortPropertiesSyntaxRewriter.SortPropertyList(node.PropertyList, out _));
                        return node;
                    }
                }
                else
                {
                    string valueText = propertySyntax.Value.ToString();
                    if ((String.IsNullOrWhiteSpace(valueText)) ||
                        (valueText.Equals("ToBeClassified", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        NoOfChanges++;

                        if ((!String.IsNullOrWhiteSpace(_tableDataClassification)) && (_tableDataClassification.Equals(DataClassification, StringComparison.CurrentCultureIgnoreCase)))
                            return node.WithPropertyList(
                                node.PropertyList.WithProperties(
                                    node.PropertyList.Properties.Remove(propertySyntax)));
                        else
                            return node.ReplaceNode(propertySyntax, this.CreateDataClassificationProperty(node));
                    }
                }
            } 
            else
            {
                PropertySyntax propertySyntax = node.GetProperty("DataClassification");
                if (propertySyntax != null)
                {
                    NoOfChanges++;
                    return node.WithPropertyList(
                        node.PropertyList.WithProperties(
                            node.PropertyList.Properties.Remove(propertySyntax)));
                }
            }
            return base.VisitField(node);
        }

        protected PropertySyntax CreateDataClassificationProperty(SyntaxNode node)
        {
            var propertySyntax = SyntaxFactory.Property(
                "DataClassification",
                SyntaxFactory.EnumPropertyValue(SyntaxFactory.IdentifierName(this.DataClassification)));

            SyntaxTriviaList leadingTriviaList = node.CreateChildNodeIdentTrivia();
            SyntaxTriviaList trailingTriviaList = SyntaxFactory.ParseTrailingTrivia("\r\n", 0);
            propertySyntax = propertySyntax
                .WithLeadingTrivia(leadingTriviaList)
                .WithTrailingTrivia(trailingTriviaList);

            return propertySyntax;

            /*
            return SyntaxFactory.Property(
                SyntaxFactory.PropertyName(SyntaxFactory.Identifier("DataClassification"))
                    .WithTrailingTrivia(SyntaxFactory.ParseTrailingTrivia(" ")),
                SyntaxFactory.EnumPropertyValue(SyntaxFactory.IdentifierName(this.DataClassification))
                    .WithLeadingTrivia(SyntaxFactory.ParseLeadingTrivia(" ")))
                .WithLeadingTrivia(leadingTriviaList)                
                .WithTrailingTrivia(trailingTriviaList);
            */
        }


    }
}
