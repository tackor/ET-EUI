namespace ET
{
    public static class ESCommonUI_TestSystem
    {
        public static void SetLabelContent(this ESCommonUI_Test self, string message)
        {
            self.EText_Test2Text.text = message;
        }
    }
}