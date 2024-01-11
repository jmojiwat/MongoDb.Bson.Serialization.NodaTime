using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class YearMonthSerializer : SerializerBase<YearMonth>
{
    public override YearMonth Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        YearMonthPattern.Iso.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, YearMonth value) => 
        context.Writer.WriteString(YearMonthPattern.Iso.Format(value));
}