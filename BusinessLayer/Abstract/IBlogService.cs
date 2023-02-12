using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        //Summary:Catefory İnclude
        //
        //
        //Return : List Blog Listesi İnclude Kategoriler
        List<Blog> TGetBlogInListAll();

        //Summary: Yazara Göre Blog Listesi
        List<Blog> TGetBlogListByWriter(int id);

        // Return: Yazarın son blogları
        List<Blog> TGetLastBlogs(int count);
    }
}
