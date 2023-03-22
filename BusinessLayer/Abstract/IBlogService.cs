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
        /// <summary>
        /// Category Tablosunu Include ederek Blog Listesini Döndürür
        /// </summary>
        /// <returns> blog listesi</returns>
        List<Blog> TGetBlogInListAll();

        /// <summary>
        /// yazarın Tüm Bloglarını listeler
        /// </summary>
        /// <param name="id"> yazar ID</param>
        /// <returns>Blog Listesi</returns>
        List<Blog> TGetBlogListByWriter(int id);

        /// <summary>
        /// Durumu True Olan Blogları Döndürür Category Tablosunu Include eder
        /// </summary>
        /// <returns>Blog Listesi</returns>
        List<Blog> TGetBlogListByTrue();

        /// <summary>
        /// Yazarın Tüm bloglarını kategorileri include ederek getirir
        /// </summary>
        /// <param name="id">Yazar ID</param>
        /// <returns></returns>
        List<Blog> TGetBlogListByWriterWithCategory(int id);

        /// <summary>
        /// Tüm Bloglar arasında Durumu true olan bloglar arasında Tarih sıralaması yaparak en son paylaşılan Blogları Parametreye Göre çağırır
        /// </summary>
        /// <param name="count">Kaç Blog Listelenecek</param>
        /// <returns>Blog Listesi</returns>
        List<Blog> TGetLastBlogs(int count);

        /// <summary>
        /// parametreye göre son blogları listelemek için kullanılır
        /// includes Categories and Writers
        /// </summary>
        /// <param name="count">sondan kaç tane bloğun listelenmek istediğini ister</param>
        /// <returns>parametreye göre blog listesi döndürür</returns>
        List<Blog> TGetLastBlogsWithCategoryAndWriter(int count);

        /// <summary>
        /// Yazarın blog sayısını Döndürür
        /// </summary>
        /// <param name="id">Yazar ID</param>
        /// <returns>int Blog Sayısı</returns>
        int TWriterBlogCount(int id);

        /// <summary>
        /// Yazarın parametreye Göre En son Paylaştığı Bloglar
        /// </summary>
        /// <param name="id">Yazar ID</param>
        /// <param name="count">Blog Sayısı (Sondan kaç blog)</param>
        /// <returns>Blog Listesi</returns>
        List<Blog> TGetRecentBlogListByWriter(int id,int count);
    }
}
