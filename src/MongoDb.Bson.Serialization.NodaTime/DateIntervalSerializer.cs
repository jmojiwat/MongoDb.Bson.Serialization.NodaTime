using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class DateIntervalSerializer : SerializerBase<DateInterval>
{
    public override DateInterval Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartArray();
        var start = LocalDatePattern.FullRoundtrip.Parse(context.Reader.ReadString()).Value;
        var end = LocalDatePattern.FullRoundtrip.Parse(context.Reader.ReadString()).Value;
        context.Reader.ReadEndArray();

        return new DateInterval(start, end);
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateInterval value)
    {
        context.Writer.WriteStartArray();
        context.Writer.WriteString(LocalDatePattern.FullRoundtrip.Format(value.Start));
        context.Writer.WriteString(LocalDatePattern.FullRoundtrip.Format(value.End));
        context.Writer.WriteEndArray();
    }
}