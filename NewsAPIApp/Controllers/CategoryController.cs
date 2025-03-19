using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.AppHandler.Genrics.Intrefaces;
using NewsApi.AppHandler.Wrapper.WorkWrapper;
using NewsAPI.Domain.AppEntity;

namespace NewsAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            try
            {
                var Category = await _unitOfWork.Repository<Category>().GetAllWithAsync();
                return Ok(ResultResponse<IEnumerable<Category>>.Success(Category, "sucess"));
            }
            catch (Exception ex)
            {
                return Ok(ResultResponse<Category>.Fail(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Getcategory(int id)
        {
            try
            {
                var category = await _unitOfWork.Repository<Category>().GetbyIdAsync(id);

                if (category == null)
                {
                    return Ok(ResultResponse<Category>.Fail("category not found"));
                }

                return Ok(ResultResponse<Category>.Success(category, "success"));
            }
            catch (Exception ex)
            {
                return Ok(ResultResponse<Category>.Fail(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putcategory(int id, Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return Ok(ResultResponse<Category>.Fail("ID mismatch between route and object"));
                }

                // Get the existing entity from database first
                var existingcategory = await _unitOfWork.Repository<Category>().GetbyIdAsync(id);

                if (existingcategory == null)
                {
                    return Ok(ResultResponse<Category>.Fail($"category with ID {id} not found"));
                }

                // Detach the existing entity from the context
                _unitOfWork.Detach(existingcategory);

                // Now update with the new entity
                _unitOfWork.Repository<Category>().Update(category);
                await _unitOfWork.CompleteAsync();

                return Ok(ResultResponse<Category>.Success(category, "category updated successfully"));
            }
            catch (Exception ex)
            {
                return Ok(ResultResponse<Category>.Fail(ex.Message));
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> Postcategory(Category category)
        {
            try
            {
                await _unitOfWork.Repository<Category>().AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return Ok(ResultResponse<Category>.Success(category, "category created successfully"));
            }
            catch (Exception ex)
            {
                return Ok(ResultResponse<Category>.Fail(ex.Message));
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategory(int id)
        {
            try
            {
                var category = await _unitOfWork.Repository<Category>().GetbyIdAsync(id);

                if (category == null)
                {
                    return Ok(ResultResponse<Category>.Fail($"category with ID {id} not found"));
                }

                _unitOfWork.Repository<Category>().DeleteAsync(category);
                await _unitOfWork.CompleteAsync();

                return Ok(ResultResponse<object>.Success(null, "category deleted successfully"));
            }
            catch (Exception ex)
            {
                return Ok(ResultResponse<object>.Fail(ex.Message));
            }
        }
    }
}