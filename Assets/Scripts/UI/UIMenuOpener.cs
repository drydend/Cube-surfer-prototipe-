using System.Collections.Generic;

public class UIMenuOpener 
{
    private Stack<UIMenu> _openedMenus = new Stack<UIMenu>();
    
    public void OpenUIMenu(UIMenu menu)
    {
        if(_openedMenus.Count > 0)
        {
            _openedMenus.Peek().Close();
        }

        menu.Open();
        _openedMenus.Push(menu);
    }

    public void CloseCurrentUIMenu()
    {
        if(_openedMenus.Count > 0)
        {
            _openedMenus.Pop().Close();
        }
    }
}
