
           // progressbar.js@1.0.0 version is used
           // Docs: http://progressbarjs.readthedocs.org/en/1.0.0/

           var bar = new ProgressBar.Path('#heart-path', {
               easing: 'easeInOut',
               duration: 1400
           });

bar.set(3);
bar.animate(1.0);  // Number from 0.0 to 1.0

https://maps.googleapis.com/maps/api/js?key=AIzaSyBXBJuRs39sRxJ2aK0-PPQC-VGITN7Km4o&callback=initMap