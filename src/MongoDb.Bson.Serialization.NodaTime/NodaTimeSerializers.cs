using NodaTime;
using static MongoDB.Bson.Serialization.BsonSerializer;
using Duration = NodaTime.Duration;

namespace MongoDb.Bson.Serialization.NodaTime;

public static class NodaTimeSerializers
{
    public static void RegisterNodaTimeBsonSerializers()
    {
        RegisterSerializer(typeof(AnnualDate), new AnnualDateSerializer());
        RegisterSerializer(typeof(DateInterval), new DateIntervalSerializer());
        RegisterSerializer(typeof(Duration), new DurationSerializer());
        RegisterSerializer(typeof(Instant), new InstantSerializer());
        RegisterSerializer(typeof(Interval), new IntervalSerializer());
        RegisterSerializer(typeof(LocalDate), new LocalDateSerializer());
        RegisterSerializer(typeof(LocalDateTime), new LocalDateTimeSerializer());
        RegisterSerializer(typeof(LocalTime), new LocalTimeSerializer());
        RegisterSerializer(typeof(OffsetDate), new OffsetDateSerializer());
        RegisterSerializer(typeof(OffsetDateTime), new OffsetDateTimeSerializer());
        RegisterSerializer(typeof(Offset), new OffsetSerializer());
        RegisterSerializer(typeof(OffsetTime), new OffsetTimeSerializer());
        RegisterSerializer(typeof(Period), new PeriodSerializer());
        RegisterSerializer(typeof(YearMonth), new YearMonthSerializer());
        RegisterSerializer(typeof(ZonedDateTime), new ZonedDateTimeSerializer());
    }
}