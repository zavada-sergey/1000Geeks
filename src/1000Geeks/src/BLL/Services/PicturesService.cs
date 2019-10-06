using AutoMapper;
using BLL.ActualResults;
using BLL.DTO;
using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PicturesService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<ActualResult<IEnumerable<PicturesDTO>>> GetAllAsync()
        {
            try
            {
                var pictures = await _context.Pictures.ToListAsync();
                var mapping = _mapper.Map<IEnumerable<PicturesDTO>>(pictures);
                return new ActualResult<IEnumerable<PicturesDTO>> { Result = mapping };
            }
            catch (Exception e)
            {
                return new ActualResult<IEnumerable<PicturesDTO>>(e.Message);
            }
        }

        public async Task<ActualResult<PicturesDTO>> GetAsync(string hashId)
        {
            try
            {
                var pictures = await _context.Pictures.FindAsync(hashId);
                var mapping = _mapper.Map<PicturesDTO>(pictures);
                return new ActualResult<PicturesDTO> { Result = mapping };
            }
            catch (Exception e)
            {
                return new ActualResult<PicturesDTO>(e.Message);
            }
        }

        public async Task<ActualResult<string>> CreateAsync(PicturesDTO dto)
        {
            try
            {
                var mapping = _mapper.Map<Pictures>(dto);
                await _context.Pictures.AddAsync(mapping);
                await _context.SaveChangesAsync();
                return new ActualResult<string> { Result = mapping.HashId };
            }
            catch (Exception e)
            {
                return new ActualResult<string>(e.Message);
            }
        }

        public async Task<ActualResult> UpdateAsync(PicturesDTO dto)
        {
            try
            {
                _context.Entry(_mapper.Map<Pictures>(dto)).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ActualResult();
            }
            catch (Exception e)
            {
                return new ActualResult(e.Message);
            }
        }

        public async Task<ActualResult> DeleteAsync(string hashId)
        {
            try
            {
                var picture = await _context.Pictures.FindAsync(hashId);
                if (picture != null)
                {
                    _context.Pictures.Remove(picture);
                    await _context.SaveChangesAsync();
                }
                return new ActualResult();
            }
            catch (Exception e)
            {
                return new ActualResult(e.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}