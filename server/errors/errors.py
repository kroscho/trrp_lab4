from errors.typeErrors import TypeError

def getMessageError(typeError):
    if typeError is TypeError.Success.value:
        return "Успешно."
    if typeError is TypeError.NotFoundServers.value:
        return "Серверы не найдены. Попробуйте подключиться позже."
    if typeError is TypeError.ServerFull.value:
        return "Сервер переполнен."
    if typeError is TypeError.ServerFull.value:
        return "Сервер не найден."
    if typeError is TypeError.WaitingTime.value:
        return "Время ожидания вышло. Пока все серверы переполнены. Попробуйте подключиться позже."
    