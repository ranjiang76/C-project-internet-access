// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/CompanyJobEducation.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class CompanyJobEducation
  {
    static readonly string __ServiceName = "CompanyJobEducation";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobEducatioId> __Marshaller_CompanyJobEducatioId = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.CompanyJobEducatioId.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobEducationReply> __Marshaller_CompanyJobEducationReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.CompanyJobEducationReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest> __Marshaller_CompanyJobEducationRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducatioId, global::CareerCloud.gRPC.Protos.CompanyJobEducationReply> __Method_GetCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducatioId, global::CareerCloud.gRPC.Protos.CompanyJobEducationReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCompanyJobEducation",
        __Marshaller_CompanyJobEducatioId,
        __Marshaller_CompanyJobEducationReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddCompanyJobEducation",
        __Marshaller_CompanyJobEducationRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateCompanyJobEducation",
        __Marshaller_CompanyJobEducationRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteCompanyJobEducation = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCompanyJobEducation",
        __Marshaller_CompanyJobEducationRequest,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.CompanyJobEducationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CompanyJobEducation</summary>
    [grpc::BindServiceMethod(typeof(CompanyJobEducation), "BindService")]
    public abstract partial class CompanyJobEducationBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.CompanyJobEducationReply> GetCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducatioId request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CompanyJobEducation</summary>
    public partial class CompanyJobEducationClient : grpc::ClientBase<CompanyJobEducationClient>
    {
      /// <summary>Creates a new client for CompanyJobEducation</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CompanyJobEducationClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CompanyJobEducation that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CompanyJobEducationClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CompanyJobEducationClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CompanyJobEducationClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CareerCloud.gRPC.Protos.CompanyJobEducationReply GetCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducatioId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCompanyJobEducation(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CareerCloud.gRPC.Protos.CompanyJobEducationReply GetCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducatioId request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CareerCloud.gRPC.Protos.CompanyJobEducationReply> GetCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducatioId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCompanyJobEducationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CareerCloud.gRPC.Protos.CompanyJobEducationReply> GetCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducatioId request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty AddCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddCompanyJobEducation(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty AddCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> AddCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddCompanyJobEducationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> AddCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateCompanyJobEducation(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateCompanyJobEducationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCompanyJobEducation(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteCompanyJobEducation(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteCompanyJobEducation, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCompanyJobEducationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCompanyJobEducationAsync(global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteCompanyJobEducation, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override CompanyJobEducationClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CompanyJobEducationClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CompanyJobEducationBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCompanyJobEducation, serviceImpl.GetCompanyJobEducation)
          .AddMethod(__Method_AddCompanyJobEducation, serviceImpl.AddCompanyJobEducation)
          .AddMethod(__Method_UpdateCompanyJobEducation, serviceImpl.UpdateCompanyJobEducation)
          .AddMethod(__Method_DeleteCompanyJobEducation, serviceImpl.DeleteCompanyJobEducation).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CompanyJobEducationBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducatioId, global::CareerCloud.gRPC.Protos.CompanyJobEducationReply>(serviceImpl.GetCompanyJobEducation));
      serviceBinder.AddMethod(__Method_AddCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddCompanyJobEducation));
      serviceBinder.AddMethod(__Method_UpdateCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateCompanyJobEducation));
      serviceBinder.AddMethod(__Method_DeleteCompanyJobEducation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobEducationRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteCompanyJobEducation));
    }

  }
}
#endregion
