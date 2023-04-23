﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnZwDev.ALTools.ALSymbols.Internal
{
    public enum ConvertedNavTypeKind
    {
        None = 0,
        Array = 1,
        OemText = 55,
        Joker = 60,
        Table = 61,
        AnyCodeunit = 63,
        AnyEnum = 64,
        TestAction = 70,
        TestField = 71,
        TestFilterField = 74,
        TestPart = 75,
        TestFilter = 76,
        PageExtension = 106,
        TableExtension = 107,
        Profile = 108,
        PageCustomization = 110,
        QueryFilter = 111,
        EnumExtension = 112,
        ProfileExtension = 113,
        MethodReference = 200,
        RequestPage = 201,
        CurrPage = 202,
        CurrReport = 203,
        CurrXmlPort = 204,
        CurrQuery = 205,
        ReportExtension = 219,
        RequestPageExtension = 220,
        PermissionSet = 222,
        PermissionSetExtension = 223,
        Entitlement = 224,
        _ClrOption = 65536,
        CommitBehavior = 65575,
        ErrorBehavior = 65763,
        _Variable = 131072,
        Dialog = 131154,
        _Parameter = 262144,
        TestRequestPage = 262216,
        DotNet = 393268,
        TestPage = 393289,
        File = 393296,
        ControlAddIn = 393325,
        WebServiceActionContext = 393428,
        WebServiceActionResultCode = 393429,
        _ReturnValue = 524288,
        RecordRef = 917545,
        FieldRef = 917546,
        KeyRef = 917547,
        InStream = 917549,
        OutStream = 917550,
        Variant = 917554,
        FilterPageBuilder = 917585,
        SessionSettings = 917587,
        JsonToken = 917594,
        JsonObject = 917595,
        JsonArray = 917596,
        JsonValue = 917597,
        HttpClient = 917598,
        HttpRequestMessage = 917599,
        HttpResponseMessage = 917600,
        HttpHeaders = 917601,
        HttpContent = 917602,
        TextBuilder = 917603,
        Record = 917604,
        Codeunit = 917605,
        Page = 917606,
        Report = 917607,
        XmlPort = 917608,
        Query = 917609,
        XmlAttribute = 917624,
        XmlAttributeCollection = 917625,
        XmlComment = 917626,
        XmlCData = 917627,
        XmlDeclaration = 917628,
        XmlDocument = 917629,
        XmlDocumentType = 917630,
        XmlElement = 917631,
        XmlNamespaceManager = 917632,
        XmlNameTable = 917633,
        XmlNode = 917634,
        XmlNodeList = 917635,
        XmlProcessingInstruction = 917636,
        XmlText = 917637,
        XmlReadOptions = 917638,
        XmlWriteOptions = 917639,
        List = 917710,
        Dictionary = 917711,
        Version = 917713,
        ModuleInfo = 917714,
        ModuleDependencyInfo = 917715,
        DataScope = 917718,
        ErrorInfo = 917720,
        Interface = 917722,
        Action = 983060,
        TableConnectionType = 983061,
        SecurityFilter = 983062,
        TransactionType = 983063,
        DefaultLayout = 983064,
        TextEncoding = 983065,
        ExecutionMode = 983066,
        ObjectType = 983067,
        ClientType = 983069,
        ReportFormat = 983070,
        FieldType = 983072,
        FieldClass = 983073,
        NotificationScope = 983074,
        Notification = 983075,
        Verbosity = 983076,
        DataClassification = 983077,
        TelemetryScope = 983078,
        TestPermissions = 983238,
        TransactionModel = 983239,
        ExecutionContext = 983248,
        ErrorType = 983255,
        PageBackgroundTaskErrorLevel = 983257,
        AuditCategory = 983265,
        SecurityOperationResult = 983266,
        _Field = 1048576,
        _Control = 2097152,
        String = 2097214,
        TextConst = 2228235,
        Label = 2228236,
        Byte = 3014659,
        Char = 3014660,
        BigText = 3014703,
        Blob = 3145776,
        _Text = 4194304,
        _Key = 8388608,
        TableFilter = 11534380,
        Media = 11534389,
        MediaSet = 11534390,
        Boolean = 12451842,
        Integer = 12451845,
        BigInteger = 12451846,
        Decimal = 12451847,
        Option = 12451848,
        DateTime = 12451853,
        Time = 12451854,
        Date = 12451855,
        DateFormula = 12451856,
        Duration = 12451857,
        Guid = 12451858,
        RecordId = 12451880,
        Enum = 12451896,
        Text = 16646153,
        Code = 16646154
    }
}