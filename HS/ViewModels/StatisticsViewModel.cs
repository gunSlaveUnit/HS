using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace HS.ViewModels
{
    public class StatisticsViewModel : ViewModel
    {
        private readonly IStatisticsService _statisticsService;
        private int _reservationsAmountInCurrentMonth;

        public int ReservationsAmountInCurrentMonth
        {
            get => _reservationsAmountInCurrentMonth;
            set => Set(ref _reservationsAmountInCurrentMonth, value);
        }
        
        private int _reservationsAmountInPreviousMonth;

        public int ReservationsAmountInPreviousMonth
        {
            get => _reservationsAmountInPreviousMonth;
            set => Set(ref _reservationsAmountInPreviousMonth, value);
        }
        
        private int _incomeCurrentMonth;
        public int IncomeCurrentMonth
        {
            get => _incomeCurrentMonth;
            set => Set(ref _incomeCurrentMonth, value);
        }
        
        private int _incomePreviousMonth;
        public int IncomePreviousMonth
        {
            get => _incomePreviousMonth;
            set => Set(ref _incomeCurrentMonth, value);
        }
        
        private DateTime _lowerBound;

        public DateTime LowerBound
        {
            get => _lowerBound;
            set => Set(ref _lowerBound, value);
        }
        private DateTime _upperBound;
        private readonly IRepository<Reservation> _reservationsRepository;

        public DateTime UpperBound
        {
            get => _upperBound;
            set => Set(ref _upperBound, value);
        }

        private void Update()
        {
            DateTime lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime upperBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            IncomeCurrentMonth = _statisticsService.GetIncomeByTime(lowerBound, upperBound);
            IncomePreviousMonth = _statisticsService.GetIncomeByTime(
                new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1,
                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1)));
            ReservationsAmountInCurrentMonth = _statisticsService.GetReservationsByTime(
                lowerBound, upperBound).Count;
            ReservationsAmountInPreviousMonth = _statisticsService.GetReservationsByTime(
                new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, 1),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month-1,
                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month-1))).Count;
        }
        
        private ICommand _updateStatistics;
        public ICommand UpdateStatisticsCommand => _updateStatistics
            ??= new RelayCommand(OnUpdateStatisticsCommandExecuted, CanUpdateStatisticsCommandExecute);

        private bool CanUpdateStatisticsCommandExecute(object p) => true;

        private void OnUpdateStatisticsCommandExecuted(object p) => Update();
        
        private string _openedFileName = "Отчет";

        public string OpenedFileName
        {
            get => _openedFileName;
            set => Set(ref _openedFileName, value);
        }

        private string _openedFileExt = "pdf";

        public string OpenedFileExt
        {
            get => _openedFileExt;
            set => Set(ref _openedFileExt, value);
        }
        
        #region SaveFile 
        
        public ICommand SaveFileCommand { get; }

        private void OnSaveFileCommandExecuted(object p) 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = OpenedFileName ?? "Отчет";
            saveFileDialog.DefaultExt = OpenedFileExt ?? "pdf";
            saveFileDialog.Filter = "Documents (*.PDF)|" + "*.pdf";
            if (saveFileDialog.ShowDialog() == false) return;
            using PdfDocument document = new PdfDocument();
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGrid pdfGrid = new PdfGrid();
            DataTable dataTable = new DataTable();
            
            dataTable.Columns.Add("Arrival Date");
            dataTable.Columns.Add("Departure Date");
            dataTable.Columns.Add("Living Price");
            dataTable.Columns.Add("Client Document");
            dataTable.Columns.Add("Room Number");

            var items = _statisticsService.GetReservationsByPeriod(LowerBound, UpperBound);

            foreach (var item in items)
            {
                dataTable.Rows.Add(new object[]{item.ArrivalDate, item.DepartureDate, item.Cost, item.Client.Document, item.Room.Number});
            }
            
            pdfGrid.DataSource = dataTable;
            PdfGraphics graphics = page.Graphics;
            Update();
            graphics.DrawString("Rieverra Report", new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Black, new PointF(10, 10));
            graphics.DrawString($"Reservations Amount In Current Month: {ReservationsAmountInCurrentMonth}", new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new PointF(10, 50));
            graphics.DrawString($"Incomes In Current Month: {IncomeCurrentMonth}", new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new PointF(10, 60));
            pdfGrid.Draw(page, new PointF(10, 100));
            doc.Save(saveFileDialog.FileName);
            doc.Close(true);
        }
        private bool CanSaveFileCommandExecute(object p) => true;
        
        #endregion
        
        public StatisticsViewModel(IStatisticsService statisticsService,
            IRepository<Reservation> reservationsRepository)
        {
            SaveFileCommand = new RelayCommand(OnSaveFileCommandExecuted, CanSaveFileCommandExecute);
            
            _statisticsService = statisticsService;
            _reservationsRepository = reservationsRepository;

            LowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            UpperBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }
    }
}