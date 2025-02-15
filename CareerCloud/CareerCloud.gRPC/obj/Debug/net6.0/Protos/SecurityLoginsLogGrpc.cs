// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SecurityLoginsLog.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class SecurityLoginsLog
  {
    static readonly string __ServiceName = "SecurityLoginsLog";

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
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SecurityLoginsLogId> __Marshaller_SecurityLoginsLogId = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.SecurityLoginsLogId.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage> __Marshaller_SecurityLoginsLogMessage = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogId, global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage> __Method_GetSecurityLoginsLog = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogId, global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSecurityLoginsLog",
        __Marshaller_SecurityLoginsLogId,
        __Marshaller_SecurityLoginsLogMessage);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddSecurityLoginsLog = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddSecurityLoginsLog",
        __Marshaller_SecurityLoginsLogMessage,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateSecurityLoginsLog = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateSecurityLoginsLog",
        __Marshaller_SecurityLoginsLogMessage,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteSecurityLoginsLog = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteSecurityLoginsLog",
        __Marshaller_SecurityLoginsLogMessage,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.SecurityLoginsLogReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SecurityLoginsLog</summary>
    [grpc::BindServiceMethod(typeof(SecurityLoginsLog), "BindService")]
    public abstract partial class SecurityLoginsLogBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage> GetSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogId request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SecurityLoginsLog</summary>
    public partial class SecurityLoginsLogClient : grpc::ClientBase<SecurityLoginsLogClient>
    {
      /// <summary>Creates a new client for SecurityLoginsLog</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SecurityLoginsLogClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SecurityLoginsLog that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SecurityLoginsLogClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SecurityLoginsLogClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SecurityLoginsLogClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage GetSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetSecurityLoginsLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage GetSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogId request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage> GetSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogId request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetSecurityLoginsLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage> GetSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogId request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty AddSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddSecurityLoginsLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty AddSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> AddSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddSecurityLoginsLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> AddSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateSecurityLoginsLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateSecurityLoginsLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteSecurityLoginsLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteSecurityLoginsLog, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteSecurityLoginsLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteSecurityLoginsLog, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override SecurityLoginsLogClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SecurityLoginsLogClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SecurityLoginsLogBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSecurityLoginsLog, serviceImpl.GetSecurityLoginsLog)
          .AddMethod(__Method_AddSecurityLoginsLog, serviceImpl.AddSecurityLoginsLog)
          .AddMethod(__Method_UpdateSecurityLoginsLog, serviceImpl.UpdateSecurityLoginsLog)
          .AddMethod(__Method_DeleteSecurityLoginsLog, serviceImpl.DeleteSecurityLoginsLog).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SecurityLoginsLogBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetSecurityLoginsLog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogId, global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage>(serviceImpl.GetSecurityLoginsLog));
      serviceBinder.AddMethod(__Method_AddSecurityLoginsLog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddSecurityLoginsLog));
      serviceBinder.AddMethod(__Method_UpdateSecurityLoginsLog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateSecurityLoginsLog));
      serviceBinder.AddMethod(__Method_DeleteSecurityLoginsLog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteSecurityLoginsLog));
    }

  }
}
#endregion
