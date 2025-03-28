using HotChocolate.Types.Analyzers.Properties;
using Microsoft.CodeAnalysis;

namespace HotChocolate.Types.Analyzers;

public static class Errors
{
    public static readonly DiagnosticDescriptor KeyParameterMissing =
        new(
            id: "HC0074",
            title: "Parameter Missing",
            messageFormat: SourceGenResources.DataLoader_KeyParameterMissing,
            category: "DataLoader",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor MethodAccessModifierInvalid =
        new(
            id: "HC0075",
            title: "Access Modifier Invalid",
            messageFormat: SourceGenResources.DataLoader_InvalidAccessModifier,
            category: "DataLoader",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ObjectTypePartialKeywordMissing =
        new(
            id: "HC0080",
            title: "Partial Keyword Missing",
            messageFormat: "A split object type class needs to be a partial class",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ObjectTypeStaticKeywordMissing =
        new(
            id: "HC0081",
            title: "Static Keyword Missing",
            messageFormat: "A split object type class needs to be a static class",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor InterfaceTypePartialKeywordMissing =
        new(
            id: "HC0080",
            title: "Partial Keyword Missing",
            messageFormat: "A split object type class needs to be a partial class",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor InterfaceTypeStaticKeywordMissing =
        new(
            id: "HC0081",
            title: "Static Keyword Missing",
            messageFormat: "A split object type class needs to be a static class",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor TooManyNodeResolverArguments =
        new(
            id: "HC0083",
            title: "Too Many Arguments",
            messageFormat: "A node resolver can only have a single field argument called `id`",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor InvalidNodeResolverArgumentName =
        new(
            id: "HC0084",
            title: "Invalid Argument Name",
            messageFormat: "A node resolver can only have a single field argument called `id`",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor DataLoaderCannotBeGeneric =
        new(
            id: "HC0085",
            title: "DataLoader Cannot Be Generic",
            messageFormat: "The DataLoader source generator cannot generate generic DataLoaders",
            category: "DataLoader",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ConnectionSingleGenericTypeArgument =
        new(
            id: "HC0086",
            title: "Invalid Connection Structure",
            messageFormat: "A generic connection/edge type must have a single generic type argument that represents the node type",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ConnectionNameFormatIsInvalid =
        new(
            id: "HC0087",
            title: "Invalid Connection/Edge Name Format",
            messageFormat: "A connection/edge name must be in the format `{0}Edge` or `{0}Connection`",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor ConnectionNameDuplicate =
        new(
            id: "HC0088",
            title: "Invalid Connection/Edge Name",
            messageFormat: "The type `{0}` cannot be mapped to the GraphQL type name `{1}` as `{2}` is already mapped to it",
            category: "TypeSystem",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);
}
