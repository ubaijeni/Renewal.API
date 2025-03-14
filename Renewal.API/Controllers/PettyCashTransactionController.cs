using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Renewal.Services.DTOs;
using Renewal.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Renewal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PettyCashTransactionController : ControllerBase
    {
        private readonly IPettyCashTransactionService _pettyCashService;

        public PettyCashTransactionController(IPettyCashTransactionService pettyCashService)
        {
            _pettyCashService = pettyCashService;
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportTransactions([FromQuery] Guid? branchId, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var transactions = await _pettyCashService.GetAllTransactionsAsync(branchId, startDate, endDate);

            if (transactions == null || !transactions.Any())
            {
                return NotFound("No transactions found.");
            }

            // Create a new workbook and worksheet
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Transactions");

            // Use reflection to get property info
            var properties = typeof(PettyCashTransactionDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create header row
            IRow headerRow = sheet.CreateRow(0);
            for (int i = 0; i < properties.Length; i++)
            {
                headerRow.CreateCell(i).SetCellValue(properties[i].Name);
            }

            // Populate data rows
            int rowIndex = 1;
            foreach (var transaction in transactions)
            {
                IRow row = sheet.CreateRow(rowIndex++);
                for (int i = 0; i < properties.Length; i++)
                {
                    var value = properties[i].GetValue(transaction);
                    if (value != null)
                    {
                        if (value is DateTime dateTimeValue)
                        {
                            row.CreateCell(i).SetCellValue(dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else if (value is decimal decimalValue)
                        {
                            row.CreateCell(i).SetCellValue((double)decimalValue);
                        }
                        else if (value is double doubleValue)
                        {
                            row.CreateCell(i).SetCellValue(doubleValue);
                        }
                        else
                        {
                            row.CreateCell(i).SetCellValue(value.ToString());
                        }
                    }
                    else
                    {
                        row.CreateCell(i).SetCellValue(string.Empty);
                    }
                }
            }

            // Adjust column widths to fit content
            for (int i = 0; i < properties.Length; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            // Write the workbook to a MemoryStream
            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);
                var content = stream.ToArray();

                // Set the content type and attachment header
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Transactions.xlsx");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = await _pettyCashService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound("Transaction not found.");

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] AddPettyCashTransactionDTO transactionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTransaction = await _pettyCashService.AddTransactionAsync(transactionDTO);

            return CreatedAtAction(nameof(GetTransactionById), new { id = createdTransaction.TransactionID }, createdTransaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, [FromBody] UpdatePettyCashTransactionDTO transactionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pettyCashService.UpdateTransactionAsync(transactionDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            await _pettyCashService.DeleteTransactionAsync(id);
            return NoContent();
        }
    }
}


