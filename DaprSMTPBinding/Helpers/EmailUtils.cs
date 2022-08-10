namespace DaprSMTPBinding.Helpers
{
    public class EmailUtils
    {
        public static string CreateEmailBody()
        {
            return $@"
                <html>
                    <body>
                        <p>テストメールを送信しました。</p>
                        <p>日付：{DateTime.Now.ToLongDateString()}</p>
                    </body>
                </html>
            ";
        }
    }
}
