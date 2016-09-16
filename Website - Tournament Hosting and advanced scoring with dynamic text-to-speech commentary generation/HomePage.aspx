                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <%-- <style>
   .svg
   {
 mask
   }
   </style>--%>
    <div class="main-content">
        <!--/soccer-inner-->
        <div class="soccer-inner"style=" height:auto;">
            <!--/soccer-left-part-->
            <%--<div class="col-md-8 soccer-left-part">
                <!--/about-->
                <div class="about">
                    <h3 class="tittle">
                        Latest Tournament</h3>
                    <div class="sap_tabs">
                        <div id="horizontalTab" style="display: block; width: 100%; margin: 0px;">
                            <ul class="resp-tabs-list">
                                <li class="resp-tab-item grid1" aria-controls="tab_item-0" role="tab"><span>NEXT MATCH</span></li>
                                <li class="resp-tab-item grid2" aria-controls="tab_item-1" role="tab"><span>TOURNAMENT
                                    STATS</span></li>
                                <li class="resp-tab-item grid3" aria-controls="tab_item-1" role="tab"><span>TOURNAMENT
                                    TABLE</span></li>
                            </ul>
                            <div class="resp-tabs-container">
                                <div class="tab-1 resp-tab-content" aria-labelledby="tab_item-0">
                                    <div class="facts">
                                        <div class="tab_list">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td class="one">
                                                            01 June 10:00
                                                        </td>
                                                        <td class="one">
                                                            Juventus
                                                        </td>
                                                        <td class="one">
                                                            VS
                                                        </td>
                                                        <td class="one">
                                                            Sampdoria
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="one">
                                                            01 June 19:00
                                                        </td>
                                                        <td class="one">
                                                            Pro Soccer
                                                        </td>
                                                        <td class="one">
                                                            VS
                                                        </td>
                                                        <td class="one">
                                                            Genoa
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="one">
                                                            01 June 12:00
                                                        </td>
                                                        <td class="one">
                                                            Atlanta
                                                        </td>
                                                        <td class="one">
                                                            VS
                                                        </td>
                                                        <td class="one">
                                                            Napoli
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="one">
                                                            01 June 30:00
                                                        </td>
                                                        <td class="one">
                                                            Atlanta
                                                        </td>
                                                        <td class="one">
                                                            VS
                                                        </td>
                                                        <td class="one">
                                                            Fiorentina
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-1 resp-tab-content" aria-labelledby="tab_item-1">
                                    <div class="facts">
                                        <div class="tab_list">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td class="two">
                                                            Sunday 07:00 - 10:00
                                                        </td>
                                                        <td class="two">
                                                            Workout
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="two">
                                                            Sunday 14:00 - 18:00
                                                        </td>
                                                        <td class="two">
                                                            Aerobic
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="two">
                                                            Monday 07:00 - 10:00
                                                        </td>
                                                        <td class="two">
                                                            Swimming
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="two">
                                                            Wednesday 07:00 - 10:00
                                                        </td>
                                                        <td class="two">
                                                            Traning Strategy
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-1 resp-tab-content" aria-labelledby="tab_item-0">
                                    <div class="facts">
                                        <div class="tab_list">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Team
                                                        </th>
                                                        <th>
                                                            W
                                                        </th>
                                                        <th>
                                                            D
                                                        </th>
                                                        <th>
                                                            L
                                                        </th>
                                                        <th>
                                                            Point
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            1.Juventus
                                                        </td>
                                                        <td>
                                                            1
                                                        </td>
                                                        <td>
                                                            3
                                                        </td>
                                                        <td>
                                                            5
                                                        </td>
                                                        <td>
                                                            9
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            3. Atlanta
                                                        </td>
                                                        <td>
                                                            0
                                                        </td>
                                                        <td>
                                                            1
                                                        </td>
                                                        <td>
                                                            4
                                                        </td>
                                                        <td>
                                                            6
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            3. Juventus
                                                        </td>
                                                        <td>
                                                            7
                                                        </td>
                                                        <td>
                                                            6
                                                        </td>
                                                        <td>
                                                            4
                                                        </td>
                                                        <td>
                                                            7
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            4. Pro Soccer
                                                        </td>
                                                        <td>
                                                            12
                                                        </td>
                                                        <td>
                                                            7
                                                        </td>
                                                        <td>
                                                            9
                                                        </td>
                                                        <td>
                                                            20
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $('#horizontalTab').easyResponsiveTabs({
                                            type: 'default', //Types: default, vertical, accordion           
                                            width: 'auto', //auto or any width like 600px
                                            fit: true   // 100% fit in a container
                                        });
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>
                <!--//about-->
                <!--/players-->
                <div class="players">
                    <h3 class="tittle">
                        Our Players</h3>
                    <ul id="flexiselDemo3">
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#one">
                                    <img src="images/s1.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="one">
                                    <img src="images/s1.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#two">
                                    <img src="images/s3.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="two">
                                    <img src="images/s3.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#four">
                                    <img src="images/s2.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="four">
                                    <img src="images/s2.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#five">
                                    <img src="images/s1.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="five">
                                    <img src="images/s1.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#six">
                                    <img src="images/s2.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="six">
                                    <img src="images/s2.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#seven">
                                    <img src="images/s1.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="seven">
                                    <img src="images/s1.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="biseller-column">
                                <a class="lightbox" href="#eight">
                                    <img src="images/s4.jpg" alt="" />
                                </a>
                                <div class="lightbox-target" id="eight">
                                    <img src="images/s4.jpg" alt="" />
                                    <a class="lightbox-close" href="#"></a>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <!--//players-->
                <script type="text/javascript">
                    $(window).load(function () {
                        $("#flexiselDemo3").flexisel({
                            visibleItems: 3,
                            animationSpeed: 1000,
                            autoPlay: true,
                            autoPlaySpeed: 3000,
                            pauseOnHover: true,
                            enableResponsiveBreakpoints: true,
                            responsiveBreakpoints: {
                                portrait: {
                                    changePoint: 480,
                                    visibleItems: 3
                                },
                                landscape: {
                                    changePoint: 640,
                                    visibleItems: 3
                                },
                                tablet: {
                                    changePoint: 768,
                                    visibleItems: 3
                                }
                            }
                        });

                    });
                </script>
                <script type="text/javascript" src="js/jquery.flexisel.js"></script>
                <!--//players-->
                <!--/video-->
                <%--<div class="video">
							   <h3 class="tittle">Latest Video</h3>
							  <iframe src="https://player.vimeo.com/video/102114320?color=e3b92d&portrait=0"></iframe>
							</div>--%>
                <!--//video-->
                <div class="banner-slider">
                    
                    <div class="callbacks_container">
                        <h2><center>Are You Hosting  a New Tournament???</center></h2>
                   </div>
                </div> 
               <a href="Features.aspx">
                <svg width="380" height="380">
  <rect x="20" y="20" rx="120" ry="20" width="350" height="320"
  style="fill:red;stroke:black;stroke-width:5;opacity:0.5" />
   <text fill="#ffffff" font-size="45" font-family="Verdana" x="110" y="186">
   Features
  </text>
 </a>
 </svg>
  <a href="Demo.aspx">  <svg width="360" height="380">
  <rect x="20" y="20" rx="120" ry="20" width="330" height="320"
  style="fill:red;stroke:black;stroke-width:5;opacity:0.5" />
   <text fill="#ffffff" font-size="45" font-family="Verdana" x="110" y="186">
   Demo
  </text>
 </svg> </a>

  <a href="Default.aspx">  <svg width="350" height="380">
  <rect x="10" y="20" rx="120" ry="20" width="330" height="320"
  style="fill:red;stroke:black;stroke-width:5;opacity:0.5" />
   <text fill="#ffffff" font-size="45" font-family="Verdana" x="110" y="186">
   Sign In
  </text>
</svg> </a>
              
                <!--banner Slider starts Here-->
                <script src="js/responsiveslides.min.js"></script>
                <script>
                    // You can also use "$(window).load(function() {"
                    $(function () {
                        // Slideshow 3
                        $("#slider3").responsiveSlides({
                            auto: true,
                            pager: false,
                            nav: true,
                            speed: 500,
                            namespace: "callbacks",
                            before: function () {
                                $('.events').append("<li>before event fired.</li>");
                            },
                            after: function () {
                                $('.events').append("<li>after event fired.</li>");
                            }
                        });

                    });
                </script>
            </div>
            <!--//soccer-left-part-->
            <!--/soccer-right-part-->
            <div class="col-md-4 soccer-right-part">
                <%--<div class="modern">
                    <h4 class="side">
                        New Players</h4>
                    <div id="example1">
                        <div id="owl-demo" class="owl-carousel text-center">
                            <div class="item">
                                <img class="img-responsive lot" src="images/p2.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p1.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p3.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p1.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p3.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p2.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p3.jpg" alt="" />
                            </div>
                            <div class="item">
                                <img class="img-responsive lot" src="images/p1.jpg" alt="" />
                            </div>
                        </div>
                    </div>
                    <!-- requried-jsfiles-for owl -->
                    <script src="js/owl.carousel.js"></script>
                    <script>
                        $(document).ready(function () {
                            $("#owl-demo").owlCarousel({
                                items: 1,
                                lazyLoad: true,
                                autoPlay: false,
                                navigation: true,
                                navigationText: true,
                                pagination: false,
                                responsiveBreakpoints: {
                                    portrait: {
                                        changePoint: 480,
                                        visibleItems: 2
                                    },
                                    landscape: {
                                        changePoint: 640,
                                        visibleItems: 2
                                    },
                                    tablet: {
                                        changePoint: 768,
                                        visibleItems: 3
                                    }
                                }
                            });
                        });
                    </script>
                    <!-- //requried-jsfiles-for owl -->
                </div>--%>
                <!--//accordation_menu-->
                <%--<div class="list_vertical">
		         	 	<section class="accordation_menu">
						  <div>
						    <input id="label-1" name="lida" type="radio" checked="">
						   <label for="label-1" id="item1"><i class="ferme"> </i>Popular Posts<i class="icon-plus-sign i-right1"></i><i class="icon-minus-sign i-right2"></i></label>
						    <div class="content" id="a1">
						    	<div class="scrollbar" id="style-2">
								 <div class="force-overflow">
									<div class="popular-post-grids">
										<div class="popular-post-grid">
											<div class="post-img">
												<a href="single.html"><img src="images/f1.jpg" alt=""></a>
											</div>
											<div class="post-text">
												<a class="pp-title" href="single.html"> The section of the mass media industry</a>
												<p>On Feb 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>3 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
											</div>
											<div class="clearfix"></div>
										</div>
										<div class="popular-post-grid">
											<div class="post-img">
												<a href="single.html"><img src="images/f2.jpg" alt=""></a>
											</div>
											<div class="post-text">
												<a class="pp-title" href="single.html"> Lorem Ipsum is simply dummy text printing</a>
												<p>On Apr 14 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>2 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
											</div>
											<div class="clearfix"></div>
										</div>
										<div class="popular-post-grid">
											<div class="post-img">
												<a href="single.html"><img src="images/f3.jpg" alt=""></a>
											</div>
											<div class="post-text">
												<a class="pp-title" href="single.html">There are many variations of Lorem</a>
												<p>On Jun 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>0 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
											</div>
											<div class="clearfix"></div>
										</div>
										<div class="popular-post-grid">
											<div class="post-img">
												<a href="single.html"><img src="images/f4.jpg" alt=""></a>
											</div>
											<div class="post-text">
												<a class="pp-title" href="single.html">Sed ut perspiciatis unde omnis iste natus</a>
												<p>On Jan 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>1 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
											</div>
											<div class="clearfix"></div>
										</div>
									</div>
									</div>
                                </div>
                              </div>
						  </div>
						  <div>
						    <input id="label-2" name="lida" type="radio">
						    <label for="label-2" id="item2"><i class="icon-leaf" id="i2"></i>Recent Posts<i class="icon-plus-sign i-right1"></i><i class="icon-minus-sign i-right2"></i></label>
						    <div class="content" id="a2">
						       <div class="scrollbar" id="style-2">
								   <div class="force-overflow">
									<div class="popular-post-grids">
											<div class="popular-post-grid">
												<div class="post-img">
													<a href="single.html"><img src="images/f4.jpg" alt=""></a>
												</div>
												<div class="post-text">
													<a class="pp-title" href="single.html"> The section of the mass media industry</a>
													<p>On Feb 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>3 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
												</div>
												<div class="clearfix"></div>
											</div>
											<div class="popular-post-grid">
												<div class="post-img">
													<a href="single.html"><img src="images/f3.jpg" alt=""></a>
												</div>
												<div class="post-text">
													<a class="pp-title" href="single.html"> Lorem Ipsum is simply dummy text printing</a>
													<p>On Apr 14 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>2 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
												</div>
												<div class="clearfix"></div>
											</div>
											<div class="popular-post-grid">
												<div class="post-img">
													<a href="single.html"><img src="images/f1.jpg" alt=""></a>
												</div>
												<div class="post-text">
													<a class="pp-title" href="single.html">There are many variations of Lorem</a>
													<p>On Jun 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>0 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
												</div>
												<div class="clearfix"></div>
											</div>
											<div class="popular-post-grid">
												<div class="post-img">
													<a href="single.html"><img src="images/f2.jpg" alt=""></a>
												</div>
												<div class="post-text">
													<a class="pp-title" href="single.html">Sed ut perspiciatis unde omnis iste natus</a>
													<p>On Jan 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>1 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>56 </a></p>
												</div>
												<div class="clearfix"></div>
											</div>
										</div>
									</div>
								</div>
						    </div>
						  </div>
						  <div>
						    <input id="label-3" name="lida" type="radio">
						    <label for="label-3" id="item3"><i class="icon-trophy" id="i3"></i>Comments<i class="icon-plus-sign i-right1"></i><i class="icon-minus-sign i-right2"></i></label>
						    <div class="content" id="a3">
						       <div class="scrollbar" id="style-2">
							    <div class="force-overflow">
								 <div class="response">
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>MARCH 21, 2015</li>
									<li><a href="single.html">Reply</a></li>
								</ul>
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>MARCH 26, 2015</li>
									<li><a href="single.html">Reply</a></li>
								</ul>		
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>MAY 25, 2015</li>
									<li><a href="single.html">Reply</a></li>
								</ul>		
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>FEB 13, 2015</li>
									<li><a href="single.html">Reply</a></li>
								</ul>		
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>JAN 28, 2015</li>
									<li><a href="single.html">Reply</a></li>
								</ul>		
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>APR 18, 2015</li>
									<li><a href="single.html">Reply</a></li>
								</ul>		
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="media response-info">
							<div class="media-left response-text-left">
								<a href="#">
									<img class="media-object" src="images/icon1.png" alt="">
								</a>
								<h5><a href="#">User</a></h5>
							</div>
							<div class="media-body response-text-right">
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,There are many variations of passages of Lorem Ipsum available, 
									sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
								<ul>
									<li>DEC 25, 2014</li>
									<li><a href="single.html">Reply</a></li>
								</ul>		
							</div>
							<div class="clearfix"> </div>
						</div>
					</div>
					</div>
                      </div>
				</div>
				</div>
			</section>
		 </div>--%>
                <!--//accordation_menu-->
                <!--/top-news-->
                <%--<div class="top-news">
                    <h4 class="side">
                        Top Matches</h4>
                    <div class="top-inner">
                        <div class="top-text">
                            <a href="single.html">
                                <img src="images/side.jpg" class="img-responsive" alt="" /></a>
                            <h5 class="top">
                                <a href="single.html">Nulla quis lorem neque, mattis venenatis</a></h5>
                            <p>
                                On Jun 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>
                                    0 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>
                                        56 </a>
                            </p>
                        </div>
                        <div class="top-text two">
                            <a href="single.html">
                                <img src="images/side2.jpg" class="img-responsive" alt="" /></a>
                            <h5 class="top">
                                <a href="single.html">Nulla quis lorem neque, mattis venenatis</a></h5>
                            <p>
                                On Jun 25 <a class="span_link" href="#"><span class="glyphicon glyphicon-comment"></span>
                                    0 </a><a class="span_link" href="#"><span class="glyphicon glyphicon-eye-open"></span>
                                        56 </a>
                            </p>
                        </div>
                    </div>
                </div>--%>
                <!--//top-news-->
                <%--<div class="connect">
                    <h4 class="side">
                        STAY CONNECTED</h4>
                    <ul class="stay">
                        <li class="c5-element-facebook"><a href="#"><span class="icon"></span>
                            <h5>
                                700</h5>
                            <span class="text">Followers</span></a></li>
                        <li class="c5-element-twitter"><a href="#"><span class="icon1"></span>
                            <h5>
                                201</h5>
                            <span class="text">Followers</span></a></li>
                        <li class="c5-element-gg"><a href="#"><span class="icon2"></span>
                            <h5>
                                111</h5>
                            <span class="text">Followers</span></a></li>
                    </ul>
                </div>--%>
                <!--//connect-->
            </div>
            <!--//soccer-right-part-->
            <div class="clearfix">
            </div>
        </div>
        <div class="time-bg">
            <h4>
                Team 01 <span>Vs </span>Team 02</h4>
            <p id="demo">
            </p>    
            <script>
                var myVar = setInterval(function () { myTimer() }, 1000);

                function myTimer() {
                    var d = new Date();
                    document.getElementById("demo").innerHTML = d.toLocaleTimeString();
                }
            </script>
        </div>
    </div>
</asp:Content>
