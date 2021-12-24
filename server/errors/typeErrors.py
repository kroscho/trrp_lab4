from enum import Enum
     
class TypeError(Enum):
    Success = 0
    NotFoundServers = 1
    ServerFull = 2
    NotFoundServer = 3
    WaitingTime = 4