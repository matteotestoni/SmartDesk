self.addEventListener('install', e => {
	console.log('PWA Service Worker installing.');
    let timeStamp = Date.now();
    e.waitUntil(
    caches.open('app_rswstudio_service_worker').then(cache => {
      return cache.addAll([
				'/lib/foundation6/css/app.css',
				'/lib/foundation-datepicker/css/foundation-datepicker.min.css',
		        '/lib/select2/css/select2.min.css',
				'/lib/select2/css/select2-rswstudio.css',
				'/lib/foundation6/js/vendor/what-input.min.js',
				'/lib/foundation6/js/vendor/foundation.min.js',
				'/lib/foundation-datepicker/js/foundation-datepicker.min.js',
				'/lib/select2/js/select2.full.min.js',
				'https://use.fontawesome.com/releases/v5.0.13/js/all.js',
				'https://code.jquery.com/ui/1.12.1/jquery-ui.min.js',
				'/',
				'/?utm_source=homescreen'
      ])
      .then(() => self.skipWaiting());
    })
  )
});

self.addEventListener('activate',  event => {
  console.log('PWA Service Worker activating.');  
  event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', event => {
  event.respondWith(
    caches.match(event.request).then(response => {
      return response || fetch(event.request);
    })
	
  );
});