using NFine.Data.ValueObjects;

namespace NFine.Data.Resolver.ExpressionTree
{
    class LikeNode : Node
    {
        public LikeMethod Method { get; set; }
        public MemberNode MemberNode { get; set; }
        public string Value { get; set; }
    }
}
