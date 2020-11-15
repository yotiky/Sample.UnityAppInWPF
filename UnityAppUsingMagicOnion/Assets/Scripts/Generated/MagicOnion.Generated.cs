// <auto-generated />
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace MagicOnion
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::MagicOnion;
    using global::MagicOnion.Client;

    public static partial class MagicOnionInitializer
    {
        static bool isRegistered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(isRegistered) return;
            isRegistered = true;

            MagicOnionClientRegistry<Sample.Shared.ISampleService>.Register((x, y, z) => new Sample.Shared.SampleServiceClient(x, y, z));

            StreamingHubClientRegistry<Sample.Shared.ISampleHub, Sample.Shared.ISampleHubReceiver>.Register((a, _, b, c, d, e) => new Sample.Shared.SampleHubClient(a, b, c, d, e));
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace MagicOnion.Resolvers
{
    using System;
    using MessagePack;

    public class MagicOnionResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new MagicOnionResolver();

        MagicOnionResolver()
        {

        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                var f = MagicOnionResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class MagicOnionResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static MagicOnionResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(5)
            {
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion, string>), 0 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>), 1 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<int, int>), 2 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<string, string>), 3 },
                {typeof(global::Sample.Shared.RotatableAxis), 4 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }

            switch (key)
            {
                case 0: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::UnityEngine.Vector3, global::UnityEngine.Quaternion, string>(default(global::UnityEngine.Vector3), default(global::UnityEngine.Quaternion), default(string));
                case 1: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(default(global::UnityEngine.Vector3), default(global::UnityEngine.Quaternion));
                case 2: return new global::MagicOnion.DynamicArgumentTupleFormatter<int, int>(default(int), default(int));
                case 3: return new global::MagicOnion.DynamicArgumentTupleFormatter<string, string>(default(string), default(string));
                case 4: return new MagicOnion.Formatters.RotatableAxisFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace MagicOnion.Formatters
{
    using System;
    using MessagePack;

    public sealed class RotatableAxisFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Sample.Shared.RotatableAxis>
    {
        public void Serialize(ref MessagePackWriter writer, global::Sample.Shared.RotatableAxis value, MessagePackSerializerOptions options)
        {
            writer.Write((Int32)value);
        }
        
        public global::Sample.Shared.RotatableAxis Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return (global::Sample.Shared.RotatableAxis)reader.ReadInt32();
        }
    }


}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace Sample.Shared {
    using System;
    using MagicOnion;
    using MagicOnion.Client;
    using Grpc.Core;
    using MessagePack;

    [Ignore]
    public class SampleServiceClient : MagicOnionClientBase<global::Sample.Shared.ISampleService>, global::Sample.Shared.ISampleService
    {
        static readonly Method<byte[], byte[]> EchoAsyncMethod;
        static readonly Func<RequestContext, ResponseContext> EchoAsyncDelegate;
        static readonly Method<byte[], byte[]> SumAsyncMethod;
        static readonly Func<RequestContext, ResponseContext> SumAsyncDelegate;

        static SampleServiceClient()
        {
            EchoAsyncMethod = new Method<byte[], byte[]>(MethodType.Unary, "ISampleService", "EchoAsync", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
            EchoAsyncDelegate = _EchoAsync;
            SumAsyncMethod = new Method<byte[], byte[]>(MethodType.Unary, "ISampleService", "SumAsync", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
            SumAsyncDelegate = _SumAsync;
        }

        SampleServiceClient()
        {
        }

        public SampleServiceClient(CallInvoker callInvoker, MessagePackSerializerOptions serializerOptions, IClientFilter[] filters)
            : base(callInvoker, serializerOptions, filters)
        {
        }

        protected override MagicOnionClientBase<ISampleService> Clone()
        {
            var clone = new SampleServiceClient();
            clone.host = this.host;
            clone.option = this.option;
            clone.callInvoker = this.callInvoker;
            clone.serializerOptions = this.serializerOptions;
            clone.filters = filters;
            return clone;
        }

        public new ISampleService WithHeaders(Metadata headers)
        {
            return base.WithHeaders(headers);
        }

        public new ISampleService WithCancellationToken(System.Threading.CancellationToken cancellationToken)
        {
            return base.WithCancellationToken(cancellationToken);
        }

        public new ISampleService WithDeadline(System.DateTime deadline)
        {
            return base.WithDeadline(deadline);
        }

        public new ISampleService WithHost(string host)
        {
            return base.WithHost(host);
        }

        public new ISampleService WithOptions(CallOptions option)
        {
            return base.WithOptions(option);
        }
   
        static ResponseContext _EchoAsync(RequestContext __context)
        {
            return CreateResponseContext<string, string>(__context, EchoAsyncMethod);
        }

        public global::MagicOnion.UnaryResult<string> EchoAsync(string name)
        {
            return InvokeAsync<string, string>("ISampleService/EchoAsync", name, EchoAsyncDelegate);
        }
        static ResponseContext _SumAsync(RequestContext __context)
        {
            return CreateResponseContext<DynamicArgumentTuple<int, int>, int>(__context, SumAsyncMethod);
        }

        public global::MagicOnion.UnaryResult<int> SumAsync(int x, int y)
        {
            return InvokeAsync<DynamicArgumentTuple<int, int>, int>("ISampleService/SumAsync", new DynamicArgumentTuple<int, int>(x, y), SumAsyncDelegate);
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace Sample.Shared {
    using Grpc.Core;
    using Grpc.Core.Logging;
    using MagicOnion;
    using MagicOnion.Client;
    using MessagePack;
    using System;
    using System.Threading.Tasks;

    [Ignore]
    public class SampleHubClient : StreamingHubClientBase<global::Sample.Shared.ISampleHub, global::Sample.Shared.ISampleHubReceiver>, global::Sample.Shared.ISampleHub
    {
        static readonly Method<byte[], byte[]> method = new Method<byte[], byte[]>(MethodType.DuplexStreaming, "ISampleHub", "Connect", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);

        protected override Method<byte[], byte[]> DuplexStreamingAsyncMethod { get { return method; } }

        readonly global::Sample.Shared.ISampleHub __fireAndForgetClient;

        public SampleHubClient(CallInvoker callInvoker, string host, CallOptions option, MessagePackSerializerOptions serializerOptions, ILogger logger)
            : base(callInvoker, host, option, serializerOptions, logger)
        {
            this.__fireAndForgetClient = new FireAndForgetClient(this);
        }
        
        public global::Sample.Shared.ISampleHub FireAndForget()
        {
            return __fireAndForgetClient;
        }

        protected override void OnBroadcastEvent(int methodId, ArraySegment<byte> data)
        {
            switch (methodId)
            {
                case -1297457280: // OnJoin
                {
                    var result = MessagePackSerializer.Deserialize<string>(data, serializerOptions);
                    receiver.OnJoin(result); break;
                }
                case 532410095: // OnLeave
                {
                    var result = MessagePackSerializer.Deserialize<string>(data, serializerOptions);
                    receiver.OnLeave(result); break;
                }
                case -552695459: // OnSendMessage
                {
                    var result = MessagePackSerializer.Deserialize<DynamicArgumentTuple<string, string>>(data, serializerOptions);
                    receiver.OnSendMessage(result.Item1, result.Item2); break;
                }
                case -114453294: // OnMovePosition
                {
                    var result = MessagePackSerializer.Deserialize<DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion, string>>(data, serializerOptions);
                    receiver.OnMovePosition(result.Item1, result.Item2, result.Item3); break;
                }
                case 586423582: // OnUpdateRotatableAxis
                {
                    var result = MessagePackSerializer.Deserialize<global::Sample.Shared.RotatableAxis>(data, serializerOptions);
                    receiver.OnUpdateRotatableAxis(result); break;
                }
                default:
                    break;
            }
        }

        protected override void OnResponseEvent(int methodId, object taskCompletionSource, ArraySegment<byte> data)
        {
            switch (methodId)
            {
                case -733403293: // JoinAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case 1368362116: // LeaveAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -601690414: // SendMessageAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -1563398489: // MovePosition
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case 1720782567: // UpdateRotatableAxisAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                default:
                    break;
            }
        }
   
        public global::System.Threading.Tasks.Task JoinAsync(string name)
        {
            return WriteMessageWithResponseAsync<string, Nil>(-733403293, name);
        }

        public global::System.Threading.Tasks.Task LeaveAsync()
        {
            return WriteMessageWithResponseAsync<Nil, Nil>(1368362116, Nil.Default);
        }

        public global::System.Threading.Tasks.Task SendMessageAsync(string message)
        {
            return WriteMessageWithResponseAsync<string, Nil>(-601690414, message);
        }

        public global::System.Threading.Tasks.Task MovePosition(global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
        {
            return WriteMessageWithResponseAsync<DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>, Nil>(-1563398489, new DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(position, rotation));
        }

        public global::System.Threading.Tasks.Task UpdateRotatableAxisAsync(global::Sample.Shared.RotatableAxis axis)
        {
            return WriteMessageWithResponseAsync<global::Sample.Shared.RotatableAxis, Nil>(1720782567, axis);
        }


        class FireAndForgetClient : global::Sample.Shared.ISampleHub
        {
            readonly SampleHubClient __parent;

            public FireAndForgetClient(SampleHubClient parentClient)
            {
                this.__parent = parentClient;
            }

            public global::Sample.Shared.ISampleHub FireAndForget()
            {
                throw new NotSupportedException();
            }

            public Task DisposeAsync()
            {
                throw new NotSupportedException();
            }

            public Task WaitForDisconnect()
            {
                throw new NotSupportedException();
            }

            public global::System.Threading.Tasks.Task JoinAsync(string name)
            {
                return __parent.WriteMessageAsync<string>(-733403293, name);
            }

            public global::System.Threading.Tasks.Task LeaveAsync()
            {
                return __parent.WriteMessageAsync<Nil>(1368362116, Nil.Default);
            }

            public global::System.Threading.Tasks.Task SendMessageAsync(string message)
            {
                return __parent.WriteMessageAsync<string>(-601690414, message);
            }

            public global::System.Threading.Tasks.Task MovePosition(global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
            {
                return __parent.WriteMessageAsync<DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>>(-1563398489, new DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(position, rotation));
            }

            public global::System.Threading.Tasks.Task UpdateRotatableAxisAsync(global::Sample.Shared.RotatableAxis axis)
            {
                return __parent.WriteMessageAsync<global::Sample.Shared.RotatableAxis>(1720782567, axis);
            }

        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612