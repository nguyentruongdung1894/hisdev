using NencerHis.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace NencerHis.Helpers
{
    public static class Helper
    {
        // Lấy ra 1 lambda function trả về 1 property của object theo tên property truyền vào.
        // VD: x => x.Name tương đương GetPropertyFunc<T>("Name")
        public static Expression<Func<T, object>> GetPropertyFunc<T>(string propertyName)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            var convertExp = Expression.Convert(propertyExp, typeof(object));
            return Expression.Lambda<Func<T, object>>(convertExp, parameterExp);
        }

        /// <summary>
        /// Update cột số thứ tự trong dataGrid
        /// </summary>
        /// <param name="dataGrid">Control dataGridView</param>
        /// <param name="skipCount">Số phân trang</param>
        /// <param name="columnName">Tên cột</param>
        public static bool UpdateSttDataGrid(DataGridView dataGrid, int skipCount = 0, string columnName = "stt")
        {
            if (dataGrid != null)
            {
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    try
                    {
                        dataGrid.Rows[i].Cells[columnName].Value = (i + 1 + skipCount).ToString();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Xử lý sự kiện keyDown chỉ cho nhập số nguyên >= 0
        /// </summary>
        public static void ValidateInteger_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu người dùng ấn tổ hợp phím Ctrl + V (paste)
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Lấy nội dung trong clipboard
                string clipboardText = Clipboard.GetText();

                // Kiểm tra nếu có ký tự không phải số
                if (clipboardText.Any(c => !char.IsDigit(c)))
                {
                    e.SuppressKeyPress = true; // Can thiệp và không cho phép thao tác paste
                    e.Handled = true;
                    return; // Thoát khỏi sự kiện
                }
            }

            // Kiểm tra ký tự nhập từ bàn phím
            else if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)) // Nếu ký tự không phải là số
            {
                // Loại trừ phím số trên bàn phím số
               if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Loại trừ các phím kiểm soát như Backspace, Left, Right,...
                    if (e.KeyCode != Keys.Back && 
                        e.KeyCode != Keys.Left && 
                        e.KeyCode != Keys.Right && 
                        e.KeyCode != Keys.Delete && 
                        e.KeyCode != Keys.Home &&
                        e.KeyCode != Keys.End)
                    {
                        e.SuppressKeyPress = true; // Can thiệp và không cho phép nhập
                        e.Handled = true;
                        return; // Thoát khỏi sự kiện
                    }
                }
            }

            else if (e.Shift)
            {
                e.SuppressKeyPress = true; // Can thiệp và không cho phép nhập
                e.Handled = true;
                return; // Thoát khỏi sự kiện
            }
        }

        /// <summary>
        /// Kiểm tra các textBox có text isNullOrEmpty, nếu có textBox ko hợp lệ thì return false.
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns>true: nếu tất cả các textBox đều ko rỗng.</returns>
        public static bool TextBoxIsValid(params Control[] textBoxes)
        {
            foreach (var item in textBoxes)
            {
                try
                {
                    if (string.IsNullOrEmpty(item.Text.Trim()))
                    {
                        item.Focus();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    LogHelper.Exception(e.Message, e);
                    continue;
                }
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra các combobox có value, nếu có combobox ko hợp lệ thì return false.
        /// </summary>
        /// <param name="comboboxs"></param>
        /// <returns>true: nếu tất cả các combobox đều có value.</returns>
        public static bool ComboBoxIsValid(params ComboBox[] comboboxs)
        {
            foreach (var item in comboboxs)
            {
                try
                {
                    if (item.SelectedItem == null)
                    {
                        item.Focus();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    LogHelper.Exception(e.Message, e);
                    continue;
                }
            }

            return true;
        }

        /// <summary>
        /// Lấy ra thời gian tương đối giữa giờ truyền vào đến hiện tại.
        /// </summary>
        /// <param name="date">Thời gian ghi nhận</param>
        /// <returns>VD: 2 phút trước, 2 ngày trước,...</returns>
        public static string GetRelationDateStringToNow(DateTime date)
        {
            var now = DateTime.Now;
            var timeSpan = (now - date);
            var day = timeSpan.TotalDays;
            if (day >= 1 && day <= 31)
            {
                return (int)day == 1 ? string.Format(LocalExt.Text("DayAgo"), (int)day) : string.Format(LocalExt.Text("DaysAgo"), (int)day);
            }
            else if (day > 31 && day <= 365)
            {
                var month = (int)day / 30;
                return month == 1 ? string.Format(LocalExt.Text("MonthAgo"), month) : string.Format(LocalExt.Text("MonthsAgo"), month);
            }
            else if (day > 365)
            {
                var year = (int)day / 365;
                return year == 1 ? string.Format(LocalExt.Text("YearAgo"), year) : string.Format(LocalExt.Text("YearsAgo"), year);
            }
            else if (day < 1 && timeSpan.TotalHours > 1)
            {
                var hour = (int)timeSpan.TotalHours;
                return hour == 1 ? string.Format(LocalExt.Text("HourAgo"), hour) : string.Format(LocalExt.Text("HoursAgo"), hour);
            }
            else
            {
                var minute = Math.Max(1, (int)timeSpan.TotalMinutes);
                return minute == 1 ? string.Format(LocalExt.Text("MinuteAgo"), minute) : string.Format(LocalExt.Text("MinutesAgo"), minute);
            }
        }

        /// <summary>
        /// Chuyển đổi text => Sentence case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string pattern = @"(^[a-z])|[?!.:;]\s*(?=[a-z])";
            string sentenceCase = Regex.Replace(input.ToLower(), pattern, m => m.Value.ToUpper());

            return sentenceCase;
        }

        /// <summary>
        /// Chuyển text từ null về empty
        /// </summary>
        /// <param name="input">Đầu vào 1 text</param>
        /// <returns>1 string không bao giờ null</returns>
        public static string ToEmptyWhenNull([NotNullWhen(false)] this string? input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : input!;
        }
    }
}
