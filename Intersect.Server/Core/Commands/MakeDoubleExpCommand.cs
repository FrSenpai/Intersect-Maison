using Intersect.Server.Core.CommandParsing;
using Intersect.Server.Localization;
using Intersect.Server.Core.CommandParsing.Arguments;
using Intersect.Server.Networking;
using JetBrains.Annotations;
namespace Intersect.Server.Core.Commands
{

    internal sealed class MakeDoubleExpCommand : ServerCommand
    {

        public MakeDoubleExpCommand() : base(Strings.Commands.MakeDoubleExp, new VariableArgument<bool>(Strings.Commands.Arguments.DoubleExpBoolean, RequiredIfNotHelp, true))
        {
        }

        [NotNull]
        private VariableArgument<bool> Value => FindArgumentOrThrow<VariableArgument<bool>>();


        protected override void HandleValue(ServerContext context, ParserResult result)
        {
            Options.DoubleExp = result.Find(Value);
            PacketSender.SendGlobalMsg($@"Mode double exp : {result.Find(Value)} !");
            Console.WriteLine($@"State double exp : {result.Find(Value)}");
            Options.SaveToDisk();
        }

    }

}