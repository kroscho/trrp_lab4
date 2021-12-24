# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import dispatcher_pb2 as dispatcher__pb2


class DispatcherServiceStub(object):
    """сервис по работе со множеством серверов
    """

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.GetFilterServer = channel.unary_unary(
                '/filter.DispatcherService/GetFilterServer',
                request_serializer=dispatcher__pb2.FilterServerRequest.SerializeToString,
                response_deserializer=dispatcher__pb2.FilterServer.FromString,
                )
        self.AddFilterServer = channel.unary_unary(
                '/filter.DispatcherService/AddFilterServer',
                request_serializer=dispatcher__pb2.AddFilterServerRequest.SerializeToString,
                response_deserializer=dispatcher__pb2.AddFilterServerResponse.FromString,
                )


class DispatcherServiceServicer(object):
    """сервис по работе со множеством серверов
    """

    def GetFilterServer(self, request, context):
        """получение сервера
        """
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def AddFilterServer(self, request, context):
        """добавление нового сервера обработки
        """
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_DispatcherServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'GetFilterServer': grpc.unary_unary_rpc_method_handler(
                    servicer.GetFilterServer,
                    request_deserializer=dispatcher__pb2.FilterServerRequest.FromString,
                    response_serializer=dispatcher__pb2.FilterServer.SerializeToString,
            ),
            'AddFilterServer': grpc.unary_unary_rpc_method_handler(
                    servicer.AddFilterServer,
                    request_deserializer=dispatcher__pb2.AddFilterServerRequest.FromString,
                    response_serializer=dispatcher__pb2.AddFilterServerResponse.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'filter.DispatcherService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class DispatcherService(object):
    """сервис по работе со множеством серверов
    """

    @staticmethod
    def GetFilterServer(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/filter.DispatcherService/GetFilterServer',
            dispatcher__pb2.FilterServerRequest.SerializeToString,
            dispatcher__pb2.FilterServer.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def AddFilterServer(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/filter.DispatcherService/AddFilterServer',
            dispatcher__pb2.AddFilterServerRequest.SerializeToString,
            dispatcher__pb2.AddFilterServerResponse.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)
