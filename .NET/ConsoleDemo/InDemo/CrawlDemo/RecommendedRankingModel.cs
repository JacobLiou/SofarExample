﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlDemo
{
    public class RecommendedRankingModel
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArticleTitle { get; set; }

        /// <summary>
        /// 文章简介
        /// </summary>
        public string ArticleSummary { get; set; }

        /// <summary>
        /// 文章地址
        /// </summary>
        public string ArticleUrl { get; set; }
    }
}
