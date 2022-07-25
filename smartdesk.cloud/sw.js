self.addEventListener('install', e => {
	console.log('PWA Service Worker installing.');
    let timeStamp = Date.now();
    e.waitUntil(
    caches.open('app_rswstudio_service_worker').then(cache => {
      return cache.addAll([
				'/lib/foundation6.7.5/css/app.css',
				'/lib/foundation-datepicker/css/foundation-datepicker.min.css',
		    'https://cdnjs.cloudflare.com/ajax/libs/select2/4.1.0-rc.0/css/select2.min.css',
				'https://cdnjs.cloudflare.com/ajax/libs/what-input/5.2.12/what-input.min.js',
				'https://cdnjs.cloudflare.com/ajax/libs/foundation/6.7.5/js/foundation.min.js',
				'/lib/foundation-datepicker/js/foundation-datepicker.min.js',
				'https://cdnjs.cloudflare.com/ajax/libs/select2/4.1.0-rc.0/js/select2.min.js',
				'/lib/fontawesome6/css/all.min.css',
				'https://code.jquery.com/ui/1.13.2/jquery-ui.min.js',
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
