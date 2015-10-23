using System;


namespace RuSpeak.Infrastructure.Mappers
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
