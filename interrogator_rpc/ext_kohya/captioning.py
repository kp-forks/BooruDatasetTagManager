# pylint: disable=bad-indentation

from .interrogator import Interrogator
from .interrogators import BLIPLargeCaptioning, BLIP2Captioning, GITLargeCaptioning, Florence2Captioning


class Captioning(Interrogator):
    def start(self, net_params: dict, skip_online: bool=False):
        pass

    def stop(self):
        pass

    def predict(self, image):
        raise NotImplementedError()
    
    def predict_multi(self, image):
        raise NotImplementedError()

    def name(self):
        raise NotImplementedError()


class BLIP(Captioning):
    def __init__(self, intType):
        self.interrogator = BLIPLargeCaptioning()
        self.type = intType
    
    def start(self, net_params: dict, skip_online: bool=False):
        self.interrogator.load(skip_online=skip_online)

    def stop(self):
        self.interrogator.unload()

    def predict(self, image):
        tags = self.interrogator.apply(image)[0].split(",")
        return [t for t in tags if t]
    
    def predict_multi(self, images:list):
        captions = self.interrogator.apply(images)
        return [[t for t in caption.split(',') if t] for caption in captions]

    def name(self):
        return "BLIP"


class BLIP2(Captioning):
    def __init__(self, repo_name, intType):
        self.interrogator = BLIP2Captioning("Salesforce/" + repo_name)
        self.repo_name = repo_name
        self.type = intType
    
    def start(self, net_params: dict, skip_online: bool=False):
        self.interrogator.load(skip_online=skip_online)

    def stop(self):
        self.interrogator.unload()

    def predict(self, image):
        tags = self.interrogator.apply(image)[0].split(",")
        return [t for t in tags if t]
    
    def predict_multi(self, images:list):
        captions = self.interrogator.apply(images)
        return [[t for t in caption.split(',') if t] for caption in captions]

    def name(self):
        return self.repo_name


class GITLarge(Captioning):
    def __init__(self, intType):
        self.interrogator = GITLargeCaptioning()
        self.type = intType

    def start(self, net_params: dict, skip_online: bool=False):
        self.interrogator.load(skip_online=skip_online)

    def stop(self):
        self.interrogator.unload()

    def predict(self, image):
        tags = self.interrogator.apply(image)[0].split(",")
        return [t for t in tags if t]
    
    def predict_multi(self, images:list):
        captions = self.interrogator.apply(images)
        return [[t for t in caption.split(',') if t] for caption in captions]

    def name(self):
        return "GIT-large-COCO"


class Florence2(Captioning):
    def __init__(self, repo_name, commandsList, defPrompt, intType):
        self.interrogator = Florence2Captioning("microsoft/" + repo_name)
        self.repo_name = repo_name
        self.commands = commandsList
        self.defaultCommand = commandsList[0]
        self.defaultPrompt = defPrompt
        self.type = intType

    def start(self, net_params: dict, skip_online: bool = False):
        if 'cmd' in net_params:
            self.defaultCommand = net_params['cmd']
        if 'prompt' in net_params:
            self.defaultPrompt = net_params['prompt']
        self.interrogator.load(self.defaultCommand, self.defaultPrompt, skip_online=skip_online)

    def stop(self):
        self.interrogator.unload()

    def predict(self, image):
        res = self.interrogator.apply(image)
        #tags = res[0].split(",")
        return res #[t for t in tags if t]

    def predict_multi(self, images: list):
        captions = self.interrogator.apply(images)
        return [[caption] for caption in captions]

    def name(self):
        return self.repo_name