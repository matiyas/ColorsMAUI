using System.Windows.Input;

namespace ColorsMAUI.Behaviors;

public class PageDisappearingBehavior : Behavior<Page>
{
    protected override void OnAttachedTo(Page page)
    {
        base.OnAttachedTo(page);
        // Behavior does not see page page binding context
        // copy page binding context to behavior
        // another solution could be defining a source of the method:
        // Commnad="{ Binding Source={ x:Reference page }, Path=Save }"
        this.BindingContext = page.BindingContext;
        page.Disappearing += Page_Disappearing;
    }

    private void Page_Disappearing (object sender, EventArgs e)
    {
        if (Command != null && Command.CanExecute(CommandParameter))
            Command.Execute(CommandParameter);
    }

    #region Command
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(PageDisappearingBehavior));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(PageDisappearingBehavior));

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    #endregion
}