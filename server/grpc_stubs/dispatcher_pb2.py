# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: dispatcher.proto
"""Generated protocol buffer code."""
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='dispatcher.proto',
  package='filter',
  syntax='proto3',
  serialized_options=None,
  create_key=_descriptor._internal_create_key,
  serialized_pb=b'\n\x10\x64ispatcher.proto\x12\x06\x66ilter\"\x15\n\x13\x46ilterServerRequest\"\x1f\n\x0c\x46ilterServer\x12\x0f\n\x07\x61\x64\x64ress\x18\x01 \x01(\t\"W\n\x16\x41\x64\x64\x46ilterServerRequest\x12*\n\x0c\x66ilterServer\x18\x01 \x01(\x0b\x32\x14.filter.FilterServer\x12\x11\n\tsecretKey\x18\x02 \x01(\t\"\x19\n\x17\x41\x64\x64\x46ilterServerResponse2\xb1\x01\n\x11\x44ispatcherService\x12\x46\n\x0fGetFilterServer\x12\x1b.filter.FilterServerRequest\x1a\x14.filter.FilterServer\"\x00\x12T\n\x0f\x41\x64\x64\x46ilterServer\x12\x1e.filter.AddFilterServerRequest\x1a\x1f.filter.AddFilterServerResponse\"\x00\x62\x06proto3'
)




_FILTERSERVERREQUEST = _descriptor.Descriptor(
  name='FilterServerRequest',
  full_name='filter.FilterServerRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  create_key=_descriptor._internal_create_key,
  fields=[
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=28,
  serialized_end=49,
)


_FILTERSERVER = _descriptor.Descriptor(
  name='FilterServer',
  full_name='filter.FilterServer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  create_key=_descriptor._internal_create_key,
  fields=[
    _descriptor.FieldDescriptor(
      name='address', full_name='filter.FilterServer.address', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=b"".decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR,  create_key=_descriptor._internal_create_key),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=51,
  serialized_end=82,
)


_ADDFILTERSERVERREQUEST = _descriptor.Descriptor(
  name='AddFilterServerRequest',
  full_name='filter.AddFilterServerRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  create_key=_descriptor._internal_create_key,
  fields=[
    _descriptor.FieldDescriptor(
      name='filterServer', full_name='filter.AddFilterServerRequest.filterServer', index=0,
      number=1, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR,  create_key=_descriptor._internal_create_key),
    _descriptor.FieldDescriptor(
      name='secretKey', full_name='filter.AddFilterServerRequest.secretKey', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=b"".decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR,  create_key=_descriptor._internal_create_key),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=84,
  serialized_end=171,
)


_ADDFILTERSERVERRESPONSE = _descriptor.Descriptor(
  name='AddFilterServerResponse',
  full_name='filter.AddFilterServerResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  create_key=_descriptor._internal_create_key,
  fields=[
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=173,
  serialized_end=198,
)

_ADDFILTERSERVERREQUEST.fields_by_name['filterServer'].message_type = _FILTERSERVER
DESCRIPTOR.message_types_by_name['FilterServerRequest'] = _FILTERSERVERREQUEST
DESCRIPTOR.message_types_by_name['FilterServer'] = _FILTERSERVER
DESCRIPTOR.message_types_by_name['AddFilterServerRequest'] = _ADDFILTERSERVERREQUEST
DESCRIPTOR.message_types_by_name['AddFilterServerResponse'] = _ADDFILTERSERVERRESPONSE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

FilterServerRequest = _reflection.GeneratedProtocolMessageType('FilterServerRequest', (_message.Message,), {
  'DESCRIPTOR' : _FILTERSERVERREQUEST,
  '__module__' : 'dispatcher_pb2'
  # @@protoc_insertion_point(class_scope:filter.FilterServerRequest)
  })
_sym_db.RegisterMessage(FilterServerRequest)

FilterServer = _reflection.GeneratedProtocolMessageType('FilterServer', (_message.Message,), {
  'DESCRIPTOR' : _FILTERSERVER,
  '__module__' : 'dispatcher_pb2'
  # @@protoc_insertion_point(class_scope:filter.FilterServer)
  })
_sym_db.RegisterMessage(FilterServer)

AddFilterServerRequest = _reflection.GeneratedProtocolMessageType('AddFilterServerRequest', (_message.Message,), {
  'DESCRIPTOR' : _ADDFILTERSERVERREQUEST,
  '__module__' : 'dispatcher_pb2'
  # @@protoc_insertion_point(class_scope:filter.AddFilterServerRequest)
  })
_sym_db.RegisterMessage(AddFilterServerRequest)

AddFilterServerResponse = _reflection.GeneratedProtocolMessageType('AddFilterServerResponse', (_message.Message,), {
  'DESCRIPTOR' : _ADDFILTERSERVERRESPONSE,
  '__module__' : 'dispatcher_pb2'
  # @@protoc_insertion_point(class_scope:filter.AddFilterServerResponse)
  })
_sym_db.RegisterMessage(AddFilterServerResponse)



_DISPATCHERSERVICE = _descriptor.ServiceDescriptor(
  name='DispatcherService',
  full_name='filter.DispatcherService',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  create_key=_descriptor._internal_create_key,
  serialized_start=201,
  serialized_end=378,
  methods=[
  _descriptor.MethodDescriptor(
    name='GetFilterServer',
    full_name='filter.DispatcherService.GetFilterServer',
    index=0,
    containing_service=None,
    input_type=_FILTERSERVERREQUEST,
    output_type=_FILTERSERVER,
    serialized_options=None,
    create_key=_descriptor._internal_create_key,
  ),
  _descriptor.MethodDescriptor(
    name='AddFilterServer',
    full_name='filter.DispatcherService.AddFilterServer',
    index=1,
    containing_service=None,
    input_type=_ADDFILTERSERVERREQUEST,
    output_type=_ADDFILTERSERVERRESPONSE,
    serialized_options=None,
    create_key=_descriptor._internal_create_key,
  ),
])
_sym_db.RegisterServiceDescriptor(_DISPATCHERSERVICE)

DESCRIPTOR.services_by_name['DispatcherService'] = _DISPATCHERSERVICE

# @@protoc_insertion_point(module_scope)
