using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class IntervalSerializer : SerializerBase<Interval>
{
    public override Interval Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartArray();
        var start = InstantPattern.General.Parse(context.Reader.ReadString()).Value;
        var end = InstantPattern.General.Parse(context.Reader.ReadString()).Value;
        context.Reader.ReadEndArray();

        return new Interval(start, end);
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Interval value)
    {
        context.Writer.WriteStartArray();
        context.Writer.WriteString(InstantPattern.General.Format(value.Start));
        context.Writer.WriteString(InstantPattern.General.Format(value.End));
        context.Writer.WriteEndArray();
    }
}