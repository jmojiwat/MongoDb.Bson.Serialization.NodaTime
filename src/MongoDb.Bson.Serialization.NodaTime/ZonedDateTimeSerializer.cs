using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class ZonedDateTimeSerializer : SerializerBase<ZonedDateTime>
{
    public override ZonedDateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        ZonedDateTimePattern.ExtendedFormatOnlyIso.WithZoneProvider(DateTimeZoneProviders.Tzdb).Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ZonedDateTime value) => 
        context.Writer.WriteString(ZonedDateTimePattern.ExtendedFormatOnlyIso.Format(value));
}