using Intersect.Server.Core.CommandParsing;
using Intersect.Server.Localization;
using Intersect.Server.Core.CommandParsing.Arguments;
using Intersect.Server.Networking;
using JetBrains.Annotations;
namespace Intersect.Server.Core.Commands
{

    internal sealed class MakeDoubleExpCommand : ServerCommand
    {

        public MakeDoubleExpCommand() : base(Strings.Commands.MakeEventExp, new VariableArgument<bool>(Strings.Commands.Arguments.ExpEventBoolean, RequiredIfNotHelp, true), new VariableArgument<int>(Strings.Commands.Arguments.ValueMultiExp, RequiredIfNotHelp, true))
        {
        }

        [NotNull]
        private VariableArgument<bool> Value => FindArgumentOrThrow<VariableArgument<bool>>();

        [CanBeNull]
        private VariableArgument<int> ValueMultiExp => FindArgumentOrThrow<VariableArgument<int>>();

        protected override void HandleValue(ServerContext context, ParserResult result)
        {

            Options.DoubleExp = result.Find(Value);
            if (result.Find(ValueMultiExp) >= 1)
            {
                Options.ValueMultiExp = result.Find(ValueMultiExp);
            }
            if (result.Find(Value))
            {
                PacketSender.SendGlobalMsg($@"L'évènement XP * {result.Find(ValueMultiExp)} est maintenant activé.");
            } else
            {
                PacketSender.SendGlobalMsg($@"L'évènement XP est terminé.");
            }
            Console.WriteLine($@"Etat de l'évènement XP * {result.Find(ValueMultiExp)} : {result.Find(Value)}");
            Options.SaveToDisk();
        }

    }

}